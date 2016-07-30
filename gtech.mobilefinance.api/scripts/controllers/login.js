'use strict';

angular.module('mobileFinanceApp')
  .controller('LoginCtrl', function ($scope, $rootScope, User) {
      $rootScope.userData = new User();
  });
