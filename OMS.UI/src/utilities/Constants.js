const API_BASE_URL_DEVELOPMENT = "https://localhost:44372/api";
const API_BASE_URL_PRODUCTION = "";

const ENDPOINTS = {
    GET_ALL_ORDERS: "Orders/GetAllOrders/",
    UPDATE_ORDER: "Orders/UpdateOrder",
    GET_ALL_PROVIDERS: "Providers/GetAllProviders/",
    CREATE_ORDER: "Orders/CreateOrder/",
    DELETE_ORDER: "Orders/DeleteOrder/",

    GET_ORDER_SORTED_BY_NUMBER: 'Orders/GetOrdersSortedByNumber/',
    GET_ORDER_SORTED_BY_PROVIDERID: 'Orders/GetOrdersSortedByProviderId/',
    GET_ORDER_SORTED_BY_DATERANGE: 'Orders/GetOrdersByDateRange/',
    
};

const development = {
    API_URL_GET_ALL_ORDERS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_ORDERS}`,
    API_URL_UPDATE_ORDER: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_ORDER}`,
    API_URL_GET_ALL_PROVIDERS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_PROVIDERS}`,
    API_URL_CREATE_ORDER: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.CREATE_ORDER}`,
    API_URL_DELETE_ORDER: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.DELETE_ORDER}`,

    API_URL_GET_ORDER_SORTED_BY_DATERANGE: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ORDER_SORTED_BY_DATERANGE}`,
    API_URL_GET_ORDER_SORTED_BY_NUMBER: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ORDER_SORTED_BY_NUMBER}`,
    API_URL_GET_ORDER_SORTED_BY_PROVIDERID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ORDER_SORTED_BY_PROVIDERID}`,
};

const production = {
    API_URL_GET_ALL_ORDERS: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_ORDERS}`,
    API_URL_UPDATE_ORDER: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_ORDER}`,
    API_URL_GET_ALL_PROVIDERS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_PROVIDERS}`,
    API_URL_CREATE_ORDER: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.CREATE_ORDER}`,
    API_URL_DELETE_ORDER: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.DELETE_ORDER}`,

    API_URL_GET_ORDER_SORTED_BY_DATERANGE: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ORDER_SORTED_BY_DATERANGE}`,
    API_URL_GET_ORDER_SORTED_BY_NUMBER: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ORDER_SORTED_BY_NUMBER}`,
    API_URL_GET_ORDER_SORTED_BY_PROVIDERID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ORDER_SORTED_BY_PROVIDERID}`,
};

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;