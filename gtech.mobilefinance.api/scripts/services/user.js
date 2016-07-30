'use strict';

angular.module('mobileFinanceApp')
.factory('User', function (Base, $http, $q, $window, $rootScope, $location, toaster) {

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

    User.prototype.getActualUser = function () {
        var d = $q.defer();
        var _this = this;
        $http.get('/api/auth')
        .success(function (result) {
            _this.assignProperties(result.data);
            $rootScope.userData = _this;
            $window.sessionStorage.user = JSON.stringify($rootScope.userData);
            d.resolve(_this);
        })
        .error(function (error) {
            d.reject(error);
        });
        return d.promise;
    };

    User.prototype.login = function () {
        var d = $q.defer();
        var _this = this;
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
		    $window.sessionStorage.token = data.access_token;
		    _this.getActualUser()
            .then(function (result) {
                console.log(_this);
            },
            function (error) {
                toaster.error(error['error_description']);
                d.reject(error);
            });
		})
        .error(function (err) {
            console.log(err);
            toaster.error(err['error_description']);
            d.reject(err);
        });
        return d.promise;
    };
    User.prototype.logout = function () {
        delete $rootScope.userData;
        delete $rootScope.isAuthenticated;
        delete $window.sessionStorage.token;
        delete $window.sessionStorage.user;
        delete $window.sessionStorage.isAuthenticated;
        $location.path('/login');
    };
    return User;

});
