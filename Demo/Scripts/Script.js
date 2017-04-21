var myApp = angular
    .module("myModule", [])
    .controller("myController", function ($scope) {
        var technologies = [
            { name: "C#", likes: 0, price: 101000, dateBirth: new Date("November 23, 1980") },
            { name: "C++", likes: 0, price: 101000, dateBirth: new Date("November 3, 1980") },
            { name: "C", likes: 0, price: 100010, dateBirth: new Date("November 13, 1980") },
            { name: "2C#", likes: 0, price: 102000, dateBirth: new Date("September 23, 1980") },
            { name: "C+2+", likes: 0, price: 100020, dateBirth: new Date("April 23, 1987") },
            { name: "C2", likes: 0, price: 102000, dateBirth: new Date("December 3, 1950") }
        ];

        $scope.technologies = technologies;

        $scope.like = function (technology) {
            technology.likes++;
        }

        $scope.dislike = function (technology) {
            technology.likes--;
        }
        
        $scope.sortColumn = "name";
        $scope.reverseSort = false;

        $scope.sortData = function (column) {
            $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
            $scope.sortColumn = column;
        }

        $scope.getSortClass = function (column) {
            if ($scope.sortColumn == column) {
                return $scope.reverseSort ? 'glyphicon glyphicon-collapse-up pointer' : 'glyphicon glyphicon-collapse-down pointer';
            }
            else {
                return 'glyphicon glyphicon-sound-stereo pointer';
            }
        }

        $scope.search = function (item) {
            if ($scope.searchText == undefined) {
                return true;
            }
            else {
                if (item.name.toLowerCase().indexOf($scope.searchText.toLowerCase()) != -1 ||
                        item.price.toLowerCase().indexOf($scope.searchText.toLowerCase()) != -1) {
                    return true;
                }
            }

            return false;
        }
    });