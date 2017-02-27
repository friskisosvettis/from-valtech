/// <binding AfterBuild='Publish-Files' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp')
    , argv = require('yargs').argv
    , changed = require('gulp-changed')
    , clean = require('gulp-clean')
    , optional = require('optional')
    , userConfig = optional('./gulp-user-config.js')
    , config = require('./gulp-config.js')(userConfig)
    , debug = require('gulp-debug')
    , foreach = require('gulp-foreach')
    , glob = require('glob')
    , gutil = require('gulp-util')
    , msbuild = require('gulp-msbuild')
    , nugetRestore = require('gulp-nuget-restore')
    , path = require('path')
    , rename = require('gulp-rename')
    , runSequence = require('run-sequence')
    , watch = require('gulp-watch')
    , sourcemaps = require('gulp-sourcemaps')
    , browserSync = require('browser-sync')
    , sass = require('gulp-sass')
    , notify = require('gulp-notify')
    , reporter = require('postcss-reporter')
    , watchify = require('watchify')
    , browserify = require('browserify')
    , source = require('vinyl-source-stream')
    , index = require('gulp-index')
    , runSequence = require('run-sequence')
    , stringify = require('stringify')
    , buffer = require('vinyl-buffer')
    , uglify = require('gulp-uglify')
    , imagemin = require('gulp-imagemin')
    , handlebars = require('gulp-compile-handlebars')
    , postcss = require('gulp-postcss')
    , autoprefixer = require('autoprefixer')
;


var exec = require('child_process').exec;






/*****************************
  CONFIG
*****************************/

// Set production flag in gulp command
config.isProduction = !!(argv.production);
config.isStaticSite = !!(argv.staticsite);
config.styleguide = !!(argv.styleguide);
config.verbose = !!(argv.verbose);

// Config for asset build
config.assetConfig.reload = browserSync.reload;

gulp.task('z_config-set-webroot', function(done) {
    // Deploy to production if --production parameter is set
    if (config.isProduction) {
        config.paths.websiteRoot = config.paths.distRoot + '/webroot';
    }
    else if (config.isStaticSite) {
        gutil.log('is staticstie')
        config.paths.websiteRoot = config.assetConfig.dist;
    }

    if (typeof argv.dist === 'string') {
        config.paths.websiteRoot = argv.dist;
    }

    return done();
});

// Set build folders to config object
gulp.task('z_config-set-build-folders', ['z_config-set-webroot'], function (done) {
    if (config.hasSetBuildFolders) {
        return done();
    }

    var i;

    // Concat and apply folders containing code to config object
    config.paths.build.folders.code = config.paths.build.folders.code
                                        .concat(
                                            objToArray(glob.sync(config.paths.foundation + '/!(' + config.paths.ignore + ')'))
                                            , objToArray(glob.sync(config.paths.feature + '/!(' + config.paths.ignore + ')'))
                                            , objToArray(glob.sync(config.paths.project + '/!(' + config.paths.ignore + ')')));

    // Concat and apply folders containing TDS items to config object
    config.paths.build.folders.tds = config.paths.build.folders.tds
                                        .concat(
                                        objToArray(glob.sync(config.paths.foundation + '/*.TDS.Core/'))
                                        , objToArray(glob.sync(config.paths.foundation + '/*.TDS.Master/'))
                                        , objToArray(glob.sync(config.paths.foundation + '/*.TDS.Content/'))

                                        , objToArray(glob.sync(config.paths.feature + '/*.TDS.Core/'))
                                        , objToArray(glob.sync(config.paths.feature + '/*.TDS.Master/'))
                                        , objToArray(glob.sync(config.paths.feature + '/*.TDS.Content/'))

                                        , objToArray(glob.sync(config.paths.project + '/*.TDS.Core/'))
                                        , objToArray(glob.sync(config.paths.project + '/*.TDS.Master/'))
                                        , objToArray(glob.sync(config.paths.project + '/*.TDS.Content/'))
                                        );
    
    if (config.verbose)
    {
        gutil.log('********** Building from code folders:');
        gutil.log(config.paths.build.folders.code);

        gutil.log('********** Building from tds folders:');
        gutil.log(config.paths.build.folders.tds);
    }
    
    // Set config.hasSetBuildFolders to true when all folders has been set
    config.hasSetBuildFolders = true;

    return done();
});
// End - Set build folders to config object






/*****************************
  HELPERS
*****************************/
// Converts object to array
var objToArray = function (obj) {
    var arr = [];
    for (var i in obj) {
        if (obj.hasOwnProperty(i)) {
            arr.push(obj[i]);
        }
    }
    return arr;
};
// End - Converts object to array

// Pad number with leading zeroes
function padDigits(number, digits) {
    return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
}
// End - Pad number with leading zeroes






/*****************************
  INITIAL SETUP
*****************************/

gulp.task('Full-Publish', function () {
    config.runCleanBuilds = true;

    runSequence('z_config-set-build-folders', 'z_nuget-restore', 'z_clean-config-transformations', 'Publish-Csharp', 'z_apply-config-transformations', 'Publish-Tds', 'z_clean-assets', 'z_publish-sass', 'z_copy-assets-fonts', 'z_publish-javascript');
});

gulp.task('z_nuget-restore', ['z_config-set-build-folders'], function () {
    var solution = './' + config.paths.solutionName + '.sln';
    if (config.verbose)
    {
        gutil.log('********** Restoring Nuget Packages for solution file: ' + solution);
    }
    return gulp.src(solution).pipe(nugetRestore());
});

gulp.task('z_apply-config-transformations', ['z_config-set-webroot'], function (callback) {
    var configTransformationScriptPath = "./" + config.paths.configTransformationDir + "\\Default.ps1",
    webRootPath = config.paths.websiteRoot;

    if (config.verbose)
    {
        gutil.log("Script path: " + configTransformationScriptPath);
        gutil.log("Webroot Path: " + webRootPath);
    }

    exec("Powershell.exe  -executionpolicy remotesigned -File " + configTransformationScriptPath + " -webRootPath \"" + webRootPath + "\"", function (err, stdout, stderr) {
        console.log(stdout);
        callback(err);
    });
});









/*****************************
 WATCHERS
*****************************/

// watch assemblies
gulp.task('Auto-Publish-Assemblies', ['z_config-set-build-folders'], function () {
    var locations = config.paths.build.folders.code;
    var files = '/bin/{Valtech,' + config.paths.solutionName + '}.*.{dll,pdb}';
    var destination = config.paths.websiteRoot + '/bin/';

    watchThis(locations, files, destination);

});
// End watch assemblies

// watch views
gulp.task('Auto-Publish-Configurations', ['z_config-set-build-folders'], function () {
    var locations = config.paths.build.folders.code;
    var files = "/" + config.paths.configTransformationDir + '/**/*.xml';
    var destination = config.paths.websiteRoot;

    watchThis(locations, files, destination);
});
// End watch views

// watch views
gulp.task('Auto-Publish-Views', ['z_config-set-build-folders'], function () {
    var locations = config.paths.build.folders.code;
    var files = '/**/*.cshtml'; //TODO: This also publishes view files in /obj/, which may fail while building. /MOSV
    var destination = config.paths.websiteRoot;

    watchThis(locations, files, destination);
});
// End watch views

// Watch Everything
gulp.task('default', ['Auto-Publish-Assets', 'Auto-Publish-Views', 'Auto-Publish-Assemblies', 'Auto-Publish-Configurations'], function (done) {
    return done();
});
// End watch Everything

function watchThis(locations, files, destination) {
    for (var i = 0; i < locations.length; i++) {
        if (config.verbose) {
            console.log('********** Watching this pattern:');
            console.log(locations[i] + files);
        }
        gulp.src(locations[i] + files, {
            base: locations[i]
        }).pipe(
            watch(locations[i] + files)
          )
          .pipe(changed(destination))
            .pipe(debug({ title: '[' + new Date(Date.now()).toLocaleTimeString() + '] published ' }))
          .pipe(gulp.dest(destination)); //Do an initial publish of everything found
    }
}






/*****************************
  PUBLISH
*****************************/
// Publish C#

var publishCsharp = function (folders) {
    var dest = path.resolve(config.paths.websiteRoot),
      locations = [],
      buildConfiguration = (config.isProduction ? config.buildConfiguration.release : config.buildConfiguration.debug),
      verbosity = (config.verbose ? 'normal' : 'minimal')

    for (var i = 0; i < folders.length; i++) {
        locations.push(folders[i] + '/*.csproj');
    };
    
    gutil.log('********** publish C# projects to ' + dest + ' folder for ' + buildConfiguration);
    if (config.verbose) {
        gutil.log('Verbosity: ' + verbosity);
        gutil.log('Locations:');
        gutil.log(locations);
    }

    return gulp.src(locations)
      .pipe(foreach(function (stream, file) {
          return stream
            .pipe(debug({ title: 'Building project:' }))
            .pipe(msbuild({
                targets: ['Build'],
                configuration: buildConfiguration,
                logCommand: false,
                errorOnFail: true,
                stdout: true,
                verbosity: verbosity,
                maxcpucount: 0,
                toolsVersion: 14.0,
                nodeReuse: !config.isProduction,
                properties: {
                    DeployOnBuild: 'true',
                    DeployDefaultTarget: 'WebPublish',
                    WebPublishMethod: 'FileSystem',
                    DeleteExistingFiles: 'false',
                    publishUrl: dest,
                    _FindDependencies: 'false',
                    maxBuffer: 100000 * 1024
                }
            }));
      }));
};

gulp.task('Publish-Csharp', ['z_config-set-build-folders'], function () {
    return publishCsharp(config.paths.build.folders.code);
});
// END Publish C#


// Publish TDS items
var publishTds = function (folders) {
    var locations = []
    , buildConfiguration = (config.isProduction ? config.buildConfiguration.tds : config.buildConfiguration.debug)
    , verbosity = (config.verbose ? 'normal' : 'minimal')
    , i;

    var buildProperties = {
    };

    if (config.isProduction) {
        buildProperties.OutputPath = path.resolve(config.paths.distRoot);
        buildProperties.SolutionDir = path.resolve('./');

        gutil.log('Creating TDS packages.');
        gutil.log('Using build configuration: ' + buildConfiguration);
        gutil.log('Outputting in folder: ' + buildProperties.OutputPath);
    } else {
        buildProperties.DeployOnBuild = true;
        buildProperties.SitecoreWebUrl = config.paths.websiteUrl;
        buildProperties.SitecoreDeployFolder = config.paths.websiteRoot;


        gutil.log('Publishing TDS projects.');
        gutil.log('Using build configuration: ' + buildConfiguration);
        gutil.log('Publishing to: ' + buildProperties.SitecoreWebUrl);
    }

    for (i = 0; i < folders.length; i++) {
        locations.push(folders[i] + '*.scproj');
    };

    if (config.verbose) {
        gutil.log('Verbosity: ' + verbosity);
        gutil.log('Locations:');
        gutil.log(locations);
    }

    i = 0;

    return gulp.src(locations)
      .pipe(foreach(function (stream, file) {
          if (config.isProduction) {
              i++;
              buildProperties.PackageName = padDigits(i, 3) + '_' + path.basename(file.path, '.scproj');
          }
          return stream
            .pipe(debug({ title: 'Building TDS:' }))
            .pipe(msbuild({
                targets: ['Build'],
                configuration: buildConfiguration,
                logCommand: false,
                errorOnFail: true,
                stdout: true,
                verbosity: verbosity,
                maxcpucount: 0,
                toolsVersion: 14.0,
                nodeReuse: !config.isProduction,
                properties: buildProperties,
                maxBuffer: 100000 * 1024
            }));
      }));
};

gulp.task('Publish-Tds', ['z_config-set-build-folders'], function () {
    return publishTds(config.paths.build.folders.tds);
});
// END Publish TDS items







/*****************************
  CLEANUP
*****************************/
// Delete the 'dist' folder specified in manifest
gulp.task('z_clean-distroot', function () {
    return gulp.src(config.paths.distRoot).pipe(clean({ force: true }));
});
// END Delete the 'dist' folder specified in manifest

// Delete the tds update package folder
gulp.task('z_clean-tdspackages', function () {
    return gulp.src(config.paths.distRoot + '/_packages/').pipe(clean({ force: true }));
});
// END Delete the tds update package folder

// Delete the config transformations folder
gulp.task('z_clean-config-transformations', ['z_config-set-webroot'], function () {
    var configTransformationRootPath = config.paths.websiteRoot + "/" + config.paths.configTransformationDir;

    gulp.src(configTransformationRootPath, { read: false })
        .pipe(debug({ title: "Cleaning " }))
        .pipe(clean({ force: true })).on("error", sass.logError);
});
// END Delete the config transformations folder









/*****************************
  DEPLOYMENT
*****************************/


// Run complete build setup for CI server
gulp.task('z_CI_build-deployment-files', function () {
    config.runCleanBuilds = true;
    config.isProduction = true;

    runSequence(
        'z_config-set-build-folders',
        'z_clean-distroot',
        'z_nuget-restore',
        'Publish-Csharp',
        'Publish-Tds',
        'z_copy-tds-update-packages',
        'z_clean-tdspackages',
        'z_publish-sass',
        'z_copy-assets-fonts',
        'z_publish-javascript',
        'z_copy-assets-images'
        );
});
// END - Run complete build setup for CI server

// Copy Tds Update Packages to NuGet Directory
gulp.task('z_copy-tds-update-packages', ['z_config-set-build-folders'], function () {
    var tdsPackagesOutputFolder = config.paths.distRoot + '/_packages/';
    var folders = glob.sync(tdsPackagesOutputFolder + '**/*.update');

    return gulp.src(folders)
        .pipe(debug({ title: 'copying file: ' }))
        .pipe(gulp.dest(config.paths.distRoot + '/TDS'));
});
// End - Copy Tds Update Packages to NuGet Directory









/*****************************
  ASSETS
*****************************/

// Gulp watch start
gulp.task('Auto-Publish-Assets', ['z_config-set-webroot', 'z_clean-assets'], function () {
    runSequence('z_publish-sass', 'z_copy-assets-fonts', 'z_copy-assets-json', 'z_publish-javascript', 'z_copy-assets-images');

    if (config.isStaticSite) {
        // Start localhost
        if (config.verbose) {
            gutil.log('start localhost', config.paths.websiteRoot);
        }
        browserSync.init({
            server: {
                baseDir: config.paths.websiteRoot,
                index: "/assets/index.html"
            }
        });
    }

    // Watch sass
    gulp.watch(config.assetConfig.app + '/styles/**/*.scss', ['z_publish-sass', 'z_copy-assets-images']);

    // Watch javascript
    gulp.watch(config.assetConfig.app + '/scripts/**/*.js', ['z_publish-javascript', 'z_copy-assets-json']);

    // Watch handlebars templates
    if (config.isStaticSite) {
        runSequence('z_publish-templates', 'z_copy-assets-images');
        gulp.watch([config.assetConfig.app + '/templates/**/*.html', config.assetConfig.app + '/partials/**/*.html'], ['z_publish-templates', 'z_copy-assets-images']);
    }
});
// Gulp watch end

// Clean dist
gulp.task('z_clean-assets', function () {
    return gulp.src(config.paths.websiteRoot + '/assets/**/*.*', {read: false})
         .pipe(clean({force: true}));
});
// END Clean dist

// ✓ proxy
// gulp.task('proxy', ['sass', 'images', 'fonts', 'json'], function () {
//     var port = process.env.PORT || 4000;

//     browserSync({
//         proxy: 'https://demo-store-georgjensen.demandware.net/s/SiteGenesisGlobal/',
//         browser: 'chrome',
//         files: [config.paths.websiteRoot + '/scripts/bundle.js'],
//         rewriteRules: [
//             {
//                 match: new RegExp('/on/demandware.static/Sites-SiteGenesisGlobal-Site/-/en_GB/v1476969911561/css/style.css'),
//                 fn: function () {
//                     return '/styles/style.css'
//                 }
//             }
//         ],
//         middleware: require('serve-static')('./dist')
//     });

//     gulp.watch(config.assetConfig.app + '/styles/**/*.scss', ['sass']);
// });
// /end proxy

// Sass start
gulp.task('z_publish-sass', function () {
    var postcssProcessors = [
            autoprefixer,
            // reporter is last since it reports error as the last process
            reporter({ clearMessages: true, throwError: false })
        ];
    
    return gulp.src(config.assetConfig.app + '/styles/style.scss')
        .pipe(sourcemaps.init())
        .pipe(sass({ errLogToConsole: false, }))
        .on('error', function(err) {
            notify().write(err);
            this.emit('end');
        })
        .pipe(postcss(postcssProcessors))
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest(config.paths.websiteRoot + '/assets/styles'))
        .pipe(config.assetConfig.reload({ stream: true }));
});
// Sass end

// Browserify start
var bundler = browserify('./' + config.assetConfig.app + '/scripts/main.js', {
    paths: ['./node_modules', config.assetConfig.app]
});

gulp.task('z_publish-javascript', function () {
    function bundle() {
        return bundler.bundle()
            // log errors if they happen
            .on('error', function(err) {
                notify().write(err);
                this.emit('end');
            })
            .pipe(source('bundle.js'))
            // optional, remove if you dont want sourcemaps
            .pipe(buffer())
            .pipe(sourcemaps.init({ loadMaps: true })) // loads map from browserify file
            //.pipe(uglify())
            .pipe(sourcemaps.write('./')) // writes .map file
            .pipe(gulp.dest(config.paths.websiteRoot + '/assets/scripts'))
            .pipe(config.assetConfig.reload({ stream: true }));
    }

    return bundle();
});
// Browserify end

// Handlebars start
gulp.task('z_publish-templates', function () {
    runSequence('z_compile-handlebars', 'z_publish-template-index')
});

gulp.task('z_publish-template-index', function () {
    gulp.src(config.assetConfig.app + '/templates/index.css')
        .pipe(gulp.dest(config.paths.websiteRoot + '/assets'));

    // If running on windows, path indicators are different from unix (path\to  or  path/to)
    if (/^win/.test(process.platform)) {
        return gulp.src(config.paths.websiteRoot + '/assets/templates/sections/**/*.html')
            .pipe(index({
                'relativePath': config.assetConfig.app + '/assets',
                'item-template': (filepath, filename) => '<li class="index__item"><a class="index__item-link" href="' + filepath.replace('..\\Dist','') + '">' + filepath + '</a></li>',
            }))
            .pipe(gulp.dest(config.paths.websiteRoot + '/assets'));
    } else {
        return gulp.src(config.paths.websiteRoot + '/assets/templates/sections/**/*.html')
            .pipe(index({
                'prepend-to-output': () => '<head><link rel="stylesheet" type="text/css" href="./assets/index.css"></head><body><div class="wrapper">',
                'append-to-output': () => '</div></body>',
                'title': 'Georg Jensen',
                'title-template': (title) =>'<h1 class="index__title">Carlsberg Byen</h1>',
                'pathDepth': 7,
                'section-template': (sectionContent) => '<section class="index__section">' + sectionContent + '</section>',
                'section-heading-template': (heading) => '<h2 class="index__section-heading" style="text-transform: capitalize;">' + heading.replace('../../Dist/assets/templates/sections/', '') + '</h2>',
                'list-template': (listContent) => '<ul class="index__list">' + listContent + '</ul>',
                'item-template': (filepath, filename) => '<li class="index__item"><a class="index__item-link" href="./templates/' + filepath.replace('Dist/', '') + '/' + filename + '">' + filename.replace('../Dist/templates/', '') + '</a></li>',
                'relativePath': config.assetConfig.app + '/assets',
                'outputFile': './index.html',
                'tab-depth': 0,
                'tab-string': '  '
            }))
            .pipe(gulp.dest(config.paths.websiteRoot + '/assets'));
    }
});

var loremIpsum = require(config.assetConfig.app + '/partials/loremIpsum.json');

gulp.task('z_compile-handlebars', function () {
    var options = {
        batch : [config.assetConfig.app + '/partials', config.assetConfig.app + '/templates/components']
    };

    return gulp.src(config.assetConfig.app + '/templates/**/*.html')
        .pipe(handlebars(loremIpsum, options))
        .pipe(gulp.dest(config.paths.websiteRoot + '/assets/templates'))
        .pipe(config.assetConfig.reload({ stream: true }));
});
// Handlebars end

// Assets start
gulp.task('z_copy-assets-images', function () {
    return gulp.src(config.assetConfig.app + '/images/**/*')
        .pipe(imagemin({
            progressive: true,
            interlaced: true
        }))
        .pipe(gulp.dest(config.paths.websiteRoot + '/assets/images'));
});

gulp.task('z_copy-assets-fonts', function () {
    return gulp.src(config.assetConfig.app + '/fonts/**/*')
        .pipe(gulp.dest(config.paths.websiteRoot + '/assets/fonts'));
});

gulp.task('z_copy-assets-json', function () {
    return gulp.src(config.assetConfig.app + '/scripts/data/**/*.json')
        .pipe(gulp.dest(config.paths.websiteRoot + '/assets/scripts/data'));
});
// Assets end