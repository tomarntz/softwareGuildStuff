var myApp = angular.module('friendsApp', ['ngRoute']);

myApp.factory('friendsFactory',
    function($http) {
        //create new obj
        var webAPIProvider = {};
        var url = '/api/Friends/';
        //add get request to obj'
        webAPIProvider.getFriends = function() {
            return $http.get(url);
        };

        //add post request to obj
        webAPIProvider.saveFriend = function(friend) {
            return http.post(url, friend);
        };

        //obj is ready to use, return it to whatever controller needs it 
        return webAPIProvider;
    });

myApp.config(function($routeProvider) {
    $routeProvider
        .when('/Routes',
        {
            controller: "FriendsController",
            templateUrl: "/AngularViews/FriendsList.html"

        })
        .when('/AddFriend',
        {
            controller: "AddFriendController",
            templateUrl: '/AngularViews/AddFriend.html'
        })
        .otherwise({ redirectTo: '/Routes' });
});
myApp.controller('FriendsController',
    function($scope, friendsFactory) {
        friendsFactory.getFriends()
            .success(function(data) {
                $scope.friends = data;
            })
            .error(function(data, status) {
                alert("Oh crap status " + status);
            });
    });

myApp.controller('AddFriendController',
    function($scope, $location, friendsFactory) {
        $scope.friend = {};

        $scope.save = function() {
            friendsFactory.saveFriend($scope.friend)
                .success(function() {
                    $location.path('/Routes');
                })
                .error(function(data, status) {
                    alert("Oh crap status " + status);
                });
        };
    });