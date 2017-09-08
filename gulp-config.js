module.exports = function (userConfig) {
    userConfig = userConfig || {};

    var instanceRoot = userConfig.instanceRoot || "C:\\Websites";
    var projectName = "FOS.Website"

    var config = {
        buildConfiguration: {
            debug: "Debug",
            release: "Release",
            tds: "TDS"
        },
        hasSetBuildFolders: false, // Var to check if build folder has been set
        isProduction: false, // Check for --production flag
        styleguide: false, // Check for --styleguide flag
        verbose: false, // Check for --verbose flag
        paths: {
            configTransformationDir: "_ConfigTransformations",
            websiteRoot: instanceRoot + "\\" + projectName + "\\Website",
            websiteUrl: "http://fos.website.local",
            solutionName: projectName,
            distRoot: "dist",
            feature: "src/Feature",
            project: "src/Project",
            foundation: "src/Foundation",
            ignore: "*.TDS.*|*.Tests",
            build: {
                folders: {
                    code: [],
                    tds: []
                },
                files: {
                    scripts: [],
                    scss: [],
                    watchScss: []
                }
            }
        },
        assetConfig: {
            app: './Src/StaticSite/assets', 
            dist: './Src/StaticSite/Dist', 
            reload: ''
        }
    }

    return config;
}