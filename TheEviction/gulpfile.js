/// <binding AfterBuild='minifyDatatables, minifySiteCss' />
//The following table provides an explanation of the tasks specified in the code above:

//Task Name	    Description
//clean:js	    A task that uses the rimraf Node deletion module to remove the minified version of the site.js file.
//clean:css	    A task that uses the rimraf Node deletion module to remove the minified version of the site.css file.
//clean	        A task that calls the clean:js task, followed by the clean:css task.

//min:js	    A task that minifies and concatenates all.js files within the js folder.The.min.js files are excluded.
//min:css	    A task that minifies and concatenates all.css files within the css folder.The.min.css files are excluded.
//min	        A task that calls the min:js task, followed by the min:css task.

"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream");

var paths = {
    webroot: "./wwwroot/"
};

// Dependency Dirs
var deps = {
    "jquery": {
        "dist/*": ""
    },
    "bootstrap": {
        "dist/**/*": ""
    },
    "bootswatch": {
        "dist/**/*": ""
    }
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

//css/site.css
gulp.task("minifySiteCss", function () {
    return gulp.src(paths.webroot + "/css/*.css")
        .pipe(cssmin())
        .pipe(gulp.dest(paths.webroot + "/lib/_app"));
});

//minifyDatatables.
gulp.task("minifyDatatables", function () {
    return gulp.src(paths.webroot + "/js/*.js")
        .pipe(uglify())                                     // fluent syntax. Simply take each file and minify, uglify, compress them down.
        .pipe(gulp.dest(paths.webroot + "/lib/_app"));        // save them after they've been compressed.
});

//============cleant task BEGIN=================
gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);
//============cleant task END=================

//=============min task BEGIN======================
gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);
//=============min task END======================

gulp.task("scripts", function () {

    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            //console.log("Prepping Scripts for: " + prop + "/" + itemProp);
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/lib/dist/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);

});