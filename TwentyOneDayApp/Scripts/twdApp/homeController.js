"use strict";

twdApp.controller("Home", 
    function ($scope) {
        $scope.today = new Date();
        // the last container that was pressed.
        $scope.lastPressed = null;

        $scope.greens = [
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" }
        ];
        $scope.purples = [
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" }
        ];
        $scope.reds = [
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" }
        ];
        $scope.yellows = [
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" },
            { checked: false, food: "" }
        ];
        $scope.blues = [
            { checked: false, food: "" }
        ];
        $scope.oranges = [
            { checked: false, food: "" }
        ];

        $scope.pressed = function() {
            // when pressed, the container should be checked off for the day.
            this.row.checked = !this.row.checked;
        };
    }
);

