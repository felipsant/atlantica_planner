(function(){
  'use strict';

  angular.module('index')
         .service('indexService', ['$q', IndexService]);

  /**
   * Indexs DataService
   * Uses embedded, hard-coded data model; acts asynchronously to simulate
   * remote data service call(s).
   *
   * @returns {{loadAll: Function}}
   * @constructor
   */
  function IndexService($q){
    var menuItems = [
           { payload: '1', text: 'Never' },
           { payload: '2', text: 'Every Night' },
           { payload: '3', text: 'Weeknights' },
           { payload: '4', text: 'Weekends' },
           { payload: '5', text: 'Weekly' },
        ];

    // Promise-based API
    return {
      loadAllIndexs : function() {
        // Simulate async nature of real remote calls
        return $q.when(menuItems);
      }
    };
  }

})();
