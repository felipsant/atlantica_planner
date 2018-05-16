(function(){

  angular
       .module('index')
       .controller('IndexController', [
          'indexService', '$mdSidenav', '$mdBottomSheet', '$log', '$q',
          IndexController
       ]);

  /**
   * Main Controller for the Angular Material Starter App
   * @param $scope
   * @param $mdSidenav
   * @param avatarsService
   * @constructor
   */
  function IndexController( indexService, $mdSidenav, $mdBottomSheet, $log, $q) {
    var self = this;

    self.selected     = null;
    self.index        = [ ];
    self.selectIndex   = selectIndex;

    // Load all registered index

    indexService
          .loadAllIndexs()
          .then( function( index ) {
            self.index    = [].concat(index);
            self.selected = index[0];
          });

    // *********************************
    // Internal methods
    // *********************************

    /**
     * First hide the bottomsheet IF visible, then
     * hide or Show the 'left' sideNav area
     */
  }

})();
