//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    "use strict";

    var StorePurchaseStatus = Windows.Services.Store.StorePurchaseStatus;
    var StoreConsumableStatus = Windows.Services.Store.StoreConsumableStatus;
    var storeContext = Windows.Services.Store.StoreContext.getDefault();

    var productsListView;

    var page = WinJS.UI.Pages.define("/html/scenario3-unmanagedConsumable.html", {
        ready: function (element, options) {
            productsListView = document.getElementById('productsListView').winControl;

            document.getElementById("getAssociatedProductsButton").addEventListener("click", getAssociatedProductsButton);
            SdkSample.addSingleItemClickHandler("purchaseAddOnButton", productsListView, purchaseAddOnButton);
            SdkSample.addSingleItemClickHandler("getConsumableBalanceButton", productsListView, getConsumableBalanceButton);
            SdkSample.addSingleItemClickHandler("fulfillConsumableButton", productsListView, fulfillConsumableButton);
        }
    });

    function getAssociatedProductsButton() {
        var productKinds = ["UnmanagedConsumable"];
        storeContext.getAssociatedStoreProductsAsync(productKinds).then(function (addOns) {
            var productList = SdkSample.createProductListFromQueryResult(addOns, "UnmanagedConsumable Add-Ons");
            productsListView.itemDataSource = productList.dataSource;
        });
    }

    function purchaseAddOnButton() {
        productsListView.selection.getItems().done(function (items) {
            var itemSelected = items[0].data;
            storeContext.requestPurchaseAsync(itemSelected.storeId).then(function (result) {
                if (result.extendedError) {
                    SdkSample.reportExtendedError(result.extendedError);
                    return;
                }

                switch (result.status) {
                    case StorePurchaseStatus.alreadyPurchased:
                        WinJS.log && WinJS.log("You already bought this consumable and must fulfill it.", "samples", "error");
                        break;

                    case StorePurchaseStatus.succeeded:
                        WinJS.log && WinJS.log("You bought " + itemSelected.title, "samples", "status");
                        break;

                    case StorePurchaseStatus.notPurchased:
                        WinJS.log && WinJS.log("Product was not purchased, it may have been canceled.", "samples", "error");
                        break;

                    case StorePurchaseStatus.networkError:
                        WinJS.log && WinJS.log("Product was not purchased due to a network error.", "samples", "error");
                        break;

                    case StorePurchaseStatus.serverError:
                        WinJS.log && WinJS.log("Product was not purchased due to a server error.", "samples", "error");
                        break;

                    default:
                        WinJS.log && WinJS.log("Product was not purchased due to an unknown error.", "samples", "error");
                        break;
                }
            });
        });
    }

    function getConsumableBalanceButton() {
        productsListView.selection.getItems().done(function (items) {
            var itemSelected = items[0].data;
            storeContext.getConsumableBalanceRemainingAsync(itemSelected.storeId).then(function (result) {
                if (result.extendedError) {
                    SdkSample.reportExtendedError(result.extendedError);
                    return;
                }

                switch (result.status) {
                    case StoreConsumableStatus.insufficentQuantity:
                        WinJS.log && WinJS.log("Insufficient Quantity! Balance Remaining: " + result.balanceRemaining, "samples", "error");
                        break;
                    case StoreConsumableStatus.succeeded:
                        WinJS.log && WinJS.log("Balance Remaining: " + result.balanceRemaining, "samples", "status");
                        break;
                    case StoreConsumableStatus.networkError:
                        WinJS.log && WinJS.log("Network error retrieving consumable balance.", "samples", "error");
                        break;
                    case StoreConsumableStatus.serverError:
                        WinJS.log && WinJS.log("Server error retrieving consumable balance.", "samples", "error");
                        break;
                    default:
                        WinJS.log && WinJS.log("Unknown error retrieving consumable balance.", "samples", "error");
                        break;
                }
            });
        });
    }

    function fulfillConsumableButton() {
        productsListView.selection.getItems().done(function (items) {
            var itemSelected = items[0].data;

            // This can be used to ensure this request is never double fulfilled. The server will
            // only accept one report for this specific GUID.
            var trackingGuid = SdkSample.generateGuid();

            // Always use quantity of "1" to fulfill an Unmanaged consumable
            storeContext.reportConsumableFulfillmentAsync(itemSelected.storeId, 1, trackingGuid).then(function (result) {
                if (result.extendedError) {
                    SdkSample.reportExtendedError(result.extendedError);
                    return;
                }

                switch (result.status) {
                    case StoreConsumableStatus.insufficentQuantity:
                        WinJS.log && WinJS.log("Insufficient Quantity! Balance Remaining: " + result.balanceRemaining, "samples", "error");
                        break;
                    case StoreConsumableStatus.succeeded:
                        WinJS.log && WinJS.log("Successful fulfillment! Balance Remaining: " + result.balanceRemaining, "samples", "status");
                        break;
                    case StoreConsumableStatus.networkError:
                        WinJS.log && WinJS.log("Network error retrieving consumable balance.", "samples", "error");
                        break;
                    case StoreConsumableStatus.serverError:
                        WinJS.log && WinJS.log("Server error retrieving consumable balance.", "samples", "error");
                        break;
                    default:
                        WinJS.log && WinJS.log("Unknown error retrieving consumable balance.", "samples", "error");
                        break;
                }
            });
        });
    }
})();
