/// <binding BeforeBuild='copy' Clean='clean' />
var gulp = require("gulp"),
rimraf = require("rimraf"),
fs = require("fs");

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
    bower: "./bower_components/",
    lib: "./" + project.webroot + "/lib/"
};

gulp.task("clean", function (cb) {
    rimraf(paths.lib, cb);
});

gulp.task("copy", ["clean"], function () {
    var bower = {
        "angular": "angular/angular*.{js,map}",
        "boostrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}"
    };

    for (var destinationDir in bower) {
        gulp.src(paths.bower + bower[destinationDir])
        .pipe(gulp.dest(paths.lib + destinationDir));
    }
});
