/// <binding />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    concat = require('gulp-concat')
    uglifyCss = require('gulp-uglifycss')
    del = require('del')
    react = require('gulp-react'),
    griddle = require('griddle-react');

    gulp.task('clean', function () {
        // place code for your default task here
        del(['wwwroot/lib/generated']);
    });

    gulp.task('copyJS', function () {
        // place code for your default task here
        gulp.src(['wwwroot/lib/jquery/dist/jquery.min.js',
            'wwwroot/lib/bootstrap/dist/js/bootstrap.min.js',
            'wwwroot/lib/react/react.min.js',
            'wwwroot/lib/react/react-dom.min.js'
        ])
        .pipe(concat('third-party.js'))
        .pipe(gulp.dest('wwwroot/lib/generated/'));

        gulp.src(['node_modules/griddle-react/build/griddle.js'])
       .pipe(concat('griddle.js'))
       .pipe(gulp.dest('wwwroot/lib/generated/'));
    });

    gulp.task('reactPreCompile', function () {
        gulp.src(['Scripts/ReactSample.jsx'])
            .pipe(concat('bundle-react.js'))
            .pipe(react())
            .pipe(gulp.dest('wwwroot/lib/generated'));
    });

    gulp.task('copyCSS', function () {
        // place code for your default task here
        gulp.src(['wwwroot/lib/bootstrap/dist/css/bootstrap.min.css'])
        .pipe(uglifyCss())
        .pipe(concat('site.css'))
        .pipe(gulp.dest('wwwroot/lib/generated/'));
    });


    gulp.task('default', ['clean', 'copyJS', 'reactPreCompile', 'copyCSS']);