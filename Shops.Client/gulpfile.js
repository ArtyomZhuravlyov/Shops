"use strict";

const { src, dest } = require("gulp");
const gulp = require("gulp");
const autoprefixer = require("gulp-autoprefixer");

const cssbeautify = require("gulp-cssbeautify");
const cssnano = require("gulp-cssnano");
const plumber = require("gulp-plumber");
const rename = require("gulp-rename");
const rigger = require("gulp-rigger");
const sass = require("gulp-sass")(require('sass'));
const stripcsscomments = require("gulp-strip-css-comments");
const uglify = require("gulp-uglify");
const panini = require("panini");

var path = {
    build: {
        js: "wwwroot/dist/assets/js/",
        css: "wwwroot/dist/assets/css/"
    },
    src: {
        js: "wwwroot/src/assets/js/*.js",
        css: "wwwroot/src/assets/sass/style.scss",
    },
    watch: {
        js: "wwwroot/src/assets/js/**/*.js",
        css: "wwwroot/src/assets/sass/**/*.scss",
    }
    
}

function css() {
    return src(path.src.css)
        .pipe(plumber())
        .pipe(sass())
        .pipe(autoprefixer())
        .pipe(cssbeautify())
        .pipe(dest(path.build.css))
        .pipe(cssnano())
        .pipe(stripcsscomments())
        .pipe(rename({
            suffix: ".min",
            extname: ".css"
        }))
        .pipe(dest(path.build.css));
}

function watchFiles() {
    gulp.watch([path.watch.css], css);
}

const watch = gulp.parallel(watchFiles);

exports.css = css;
exports.watch = watch;
exports.default = watch;