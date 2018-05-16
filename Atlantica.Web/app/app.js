'use strict';
var starterApp = angular.module('starterApp', ['ngMaterial', 'users', 'ui.router']);

starterApp.config(function($mdThemingProvider, $mdIconProvider){
      $mdIconProvider
          .defaultIconSet("./assets/svg/avatars.svg", 128)
          .icon("menu"       , "./assets/svg/menu.svg"        , 24)
          .icon("share"      , "./assets/svg/share.svg"       , 24)
          .icon("google_plus", "./assets/svg/google_plus.svg" , 512)
          .icon("hangouts"   , "./assets/svg/hangouts.svg"    , 512)
          .icon("twitter"    , "./assets/svg/twitter.svg"     , 512)
          .icon("phone"      , "./assets/svg/phone.svg"       , 512);

          $mdThemingProvider.theme('default')
              .primaryPalette('blue')
              .accentPalette('red');
});

starterApp.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');
    $stateProvider
        // HOME STATES AND NESTED VIEWS ========================================
        .state('home', {
            url: '/home',
            templateUrl: 'src/index/view/index.html'
        })
        // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
        .state('user', {
            url: '/user',
            templateUrl: 'src/users/view/UserIndex.html',
            controller: 'UserController'
        });
});