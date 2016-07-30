﻿'use strict';

var app = angular.module('mobileFinanceApp');

app.factory('User', function (Base, $http) {

    // Variable que se utiliza para comprobar si un objeto tiene una propiedad
    // var hasProp = Object.prototype.hasOwnProperty;

    // Nombre de la clase
    var User;

    function User(propValues) {
        User.super.constructor.apply(this, arguments);
        this.baseApiPath = "/api/auth";
        this.username = this.username || '';
        this.password = this.password || '';
    }
    var extend = function (child, parent) {
        var key;
        for (key in parent) {
            if (hasProp.call(parent, key)) {
                child[key] = parent[key];
            }
        }

        function Ctor() {
            this.constructor = child;
        }
        Ctor.prototype = parent.prototype;
        child.prototype = new Ctor();
        child.super = parent.prototype;
        return child;
    };
    // Extender de la clase Base
    extend(User, Base);

    // Funcion que retorna las propiedades de una cuenta
    User.properties = function () {
        var at = {};
        return at;
    };

    User.prototype.login = function () {
        var query = {
            'grant_type': 'password',
            username: this.username,
            password: this.password
        };
        $http({
            method: 'POST',
            url: '/login',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: query
        })
		.success(function (data) {
		    console.log(data);
		})
        .error(function (err) {
            console.log('error');
        });
    }
    return User;

});
