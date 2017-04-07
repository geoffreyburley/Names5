namespace names5 {

    angular.module('names5', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: names5.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: names5.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: names5.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: names5.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: names5.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about/:id',
                templateUrl: '/ngApp/views/about.html',
                controller: names5.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('addName', {
                url: '/addName',
                templateUrl: '/ngApp/views/addName.html',
                controller: names5.Controllers.AddNameController,
                controllerAs: 'controller'
            })
            .state('editName', {
                url: '/editName/:id',
                templateUrl: '/ngApp/views/editName.html',
                controller: names5.Controllers.EditNameController,
                controllerAs: 'controller'
            })
            .state('editAddress', {
                url: '/editAddess/:id',
                templateUrl: '/ngApp/views/editAddress.html',
                controller: names5.Controllers.EditAddressController,
                controllerAs: 'controller'
            })
            .state('addAddressUnderName', {
                url: '/addAddressUnderName/:id',
                templateUrl: '/ngApp/views/addAddressUnderName.html',
                controller: names5.Controllers.AddAddressUnderNameController,
                controllerAs: 'controller'
            })
            .state('admin', {
                url: '/admin',
                templateUrl: '/ngApp/views/admin.html',
                controller: names5.Controllers.AdminController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('names5').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('names5').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
