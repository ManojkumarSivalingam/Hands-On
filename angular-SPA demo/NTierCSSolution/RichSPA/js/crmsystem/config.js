var crmConfigurationModule =
    angular.module('Aditi.SPA.Modules.CRM.Configuration', []);

crmConfigurationModule.constant('crmSystemServiceUrls', {
    baseUrl: 'http://localhost:59109',
    customers: 'api/customers/:id',
    orders: 'api/orders/:id'
});

crmConfigurationModule.constant('crmSystemTemplateUrls', {
    customersHome: '/js/crmsystem/partials/customers-home.html',
    customersViewer: '/js/crmsystem/partials/customers-viewer.html',
    customerDetailsViewer: '/js/crmsystem/partials/customer-details-viewer.html',
    ordersViewer: '/js/crmsystem/partials/orders-viewer.html',
    newCustomerHome: '/js/crmsystem/partials/new-customer-home.html'
});

crmConfigurationModule.constant('aditiSymbols', {
    check: '\u2713',
    cross: '\u2718'
});

crmConfigurationModule.constant('crmSystemEvents', {
    CUSTOMER_SELECTED: 'customerSelectedEvent'
});

crmConfigurationModule.constant('photoBaseUrl', '/images/customers');

crmConfigurationModule.constant('newCustomerRedirectDetails', {
    timeout: 4000,
    redirectUrl: '/crmsystem'
});