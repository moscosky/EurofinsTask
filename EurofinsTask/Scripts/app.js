var EurofinsApp = angular.module('EurofinsApp', [])

EurofinsApp.controller('ProductController', function ($scope, ProductService) {
    
    $scope.products = [];
    $scope.isNewClicked = false;

    getProducts();
    function getProducts() {
        ProductService.getProducts()
            .then(function (res) {
                $scope.products = res.data;
                console.log($scope.products);
            })
            .catch(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
                alert($scope.status);
            });
    }   

    $scope.onClickNew = function () {
        $scope.isNewClicked = true;
    } 

    $scope.onClickAdd = function (product) {
        ProductService.addProduct(product)
            .then(function (res) {
                $scope.isNewClicked = false;
                getProducts();
            })
            .catch(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
                alert($scope.status);
            });
    } 

    $scope.onClickEdit = function (product) {
        product.isEditMode = true;
    }  

    $scope.onClickUpdate = function (product) {
        ProductService.updateProduct(product)
            .then(function (res) {
                product.isEditMode = false;
            })
            .catch(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
                alert($scope.status);
            });
    } 

    $scope.onClickDelete = function (product) {
        ProductService.removeProduct(product.Id)
            .then(function (res) {
                getProducts();
            })
            .catch(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
                alert($scope.status);
            });
    } 

});

EurofinsApp.factory('ProductService', ['$http', function ($http) {
    var ProductService = {};

    ProductService.getProducts = function () {

        return $http.get('/api/Products');

    };

    ProductService.addProduct = function (product) {

        return $http.post('/api/Products', product);

    };

    ProductService.updateProduct = function (product) {

        return $http.put('/api/Products', product);

    };

    ProductService.removeProduct = function (id) {

        return $http.delete('/api/Products/' + id);

    };

    return ProductService;
}]);   