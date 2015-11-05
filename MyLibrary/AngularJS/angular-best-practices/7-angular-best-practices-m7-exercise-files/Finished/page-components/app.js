var app = angular.module('app', []);

app.controller('scNavBarCtrl', function($scope){

});
app.directive('navBar', function() {
  return {
    restrict: 'E',
    templateUrl: 'navbar.html',
    controller: 'scNavBarCtrl'
  }
});
app.controller('scNavBarLoginCtrl', function($scope, notifier){
  $scope.signin = function(name, password) {
    if(name === 'Harry' && password === 'Ginny') {
      notifier.notify('You have successfully signed in!');
      $scope.authenticated = true;
    } else {
      notifier.notify('Username/Password Combination incorrect');
    }
  }
});
app.directive('navBarLogin', function() {
  return {
    restrict: 'E',
    templateUrl: 'navbarLogin.html',
    controller: 'scNavBarLoginCtrl'
  }
});
app.controller('scCatalogCtrl', function($scope, notifier){
  $scope.registerCourse = function(course) {
    course.registered = true;
    notifier.notify('You have registered for ' + course.name);
  }
});
app.directive('catalog', function() {
  return {
    restrict: 'E',
    templateUrl: 'catalog.html',
    controller: 'scCatalogCtrl',
    scope: {
      catalog: '=data'
    }
  }
});
app.controller('scScheduleCtrl', function($scope, notifier){
  $scope.unregisterCourse = function(course) {
    course.registered = false;
    notifier.notify('You have unregistered for ' + course.name);
  }
});
app.directive('schedule', function() {
  return {
    restrict: 'E',
    templateUrl: 'schedule.html',
    controller: 'scScheduleCtrl',
    scope: {
      catalog: '='
    }
  }
});
app.controller('scFollowedInstructorsCtrl', function($scope, followedInstructors, notifier){
  $scope.followedInstructors = followedInstructors;
  $scope.unFollowInstructor = function(instructor) {
    followedInstructors.splice(followedInstructors.indexOf(instructor), 1);
    notifier.notify('You have unfollowed ' + instructor.name);
  }
});
app.directive('followedInstructors', function() {
  return {
    restrict: 'E',
    templateUrl: 'followedInstructors.html',
    controller: 'scFollowedInstructorsCtrl'
  }
});

app.controller('scRegistrationCtrl',function($scope, toastr, catalog) {

  $scope.catalog = catalog;
});
app.directive('registration', function() {
  return {
    restrict: 'E',
    templateUrl: 'registration.html',
    controller: 'scRegistrationCtrl'
  }
});

app.factory('notifier', function(toastr) {
  return {
    notify: function(msg) {
      toastr.success(msg);
      console.log(msg);
    }
  }
})