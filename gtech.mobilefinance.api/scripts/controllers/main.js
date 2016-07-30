'use strict';

/**
 * @ngdoc function
 * @name mobileFinanceApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the mobileFinanceApp
 */
angular.module('mobileFinanceApp')
  .controller('MainCtrl', function ($scope, User) {
      $scope.user = new User();
      $scope.login = function () {
          console.log($scope.user);
          $scope.user.login();
      }
  });
