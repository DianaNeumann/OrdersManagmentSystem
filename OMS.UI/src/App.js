import React, { useState } from "react";
import Constants from "./utilities/Constants";
import OrderCreateForm from "./components/OrderCreateForm";
import OrderUpdateForm from "./components/OrderUpdateForm";
import 'bootstrap/dist/css/bootstrap.min.css';


export default function App() {
  const [orders, setOrders] = useState([]);
  const [showingCreateNewOrderForm, setShowingCreateNewOrderForm] = useState(false);
  const [orderCurrentlyBeingUpdated, setOrderCurrentlyBeingUpdated] = useState(null);
  const [startDate, setStartDate] = useState(new Date(new Date().setMonth(new Date().getMonth() - 1)));
  const [endDate, setEndDate] = useState(new Date());

  function getOrders() {
    const url = Constants.API_URL_GET_ALL_ORDERS;

    fetch(url, {
      method: "GET"
    })
      .then(response => response.json())
      .then(responseFromServer => {
        setOrders(responseFromServer);
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function deleteOrder(orderId) {
    const url = `${Constants.API_URL_DELETE_ORDER}${orderId}`;
    fetch(url, {
      method: "DELETE"
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onOrderDeleted(orderId);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function sendDate() {
    const url = Constants.API_URL_GET_ORDER_SORTED_BY_DATERANGE;
    const body = JSON.stringify({
      start: startDate,
      end: endDate
    });
    console.log(body);
    fetch(url, {
      method: "POST",
      headers: {
          "Accept": 'application/json',
          "Content-Type": "application/json-patch+json"
      },
      body: body
    })
    .then(response => response.json())
    .then(responseFromServer => {
        console.log(responseFromServer);
        setOrders(responseFromServer);
    })
    .catch((error) => {
        console.log(error);
    });
  }

  function sortByNumber() {
    const url = Constants.API_URL_GET_ORDER_SORTED_BY_NUMBER;
    fetch(url, {
      method: "GET",
      headers: {
          "Accept": 'text/plain',
      },
    })
    .then(response => response.json())
    .then(responseFromServer => {
        console.log(responseFromServer);
        setOrders(responseFromServer);
    })
    .catch((error) => {
        console.log(error);
    });
  }

  function sortByProviderId() {
    const url = Constants.API_URL_GET_ORDER_SORTED_BY_PROVIDERID;
    fetch(url, {
      method: "GET",
      headers: {
          "Accept": 'text/plain',
      },
    })
    .then(response => response.json())
    .then(responseFromServer => {
        console.log(responseFromServer);
        setOrders(responseFromServer);
    })
    .catch((error) => {
        console.log(error);
    });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewOrderForm === false && orderCurrentlyBeingUpdated === null) && (
            <div>
              <h1>Order Managment System for Solforb</h1>

              <div className="mt-5">
                <button onClick={getOrders} className="btn btn-dark btn-lg w-100">Get Latest Orders from Server</button>
                <button onClick={() => setShowingCreateNewOrderForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Create new Ordert</button>
              </div>
            </div>
          )}

          {(orders.length > 0 && showingCreateNewOrderForm === false && orderCurrentlyBeingUpdated === null) && renderOrdersTable()}

          {showingCreateNewOrderForm && <OrderCreateForm onOrderCreated={onOrderCreated} />}

          {orderCurrentlyBeingUpdated !== null && <OrderUpdateForm order={orderCurrentlyBeingUpdated} onOrderUpdated={onOrderUpdated} />}
        </div>
      </div>
    </div>
  );

  function renderOrdersTable() {
    return (
      <>
        <div>
        <br></br>

        <input className="datepicker" type ="date"   onChange={(e) => setStartDate(e.target.valueAsDate)}/>
        <br></br>
        
        <input className="datepicker" type="date" onChange={(e) => setEndDate(e.target.valueAsDate)}/>
        <br></br>

        <button type="button" onClick={(e) => {
          sendDate();
        }}>Filter by date</button>
        <br></br>
        
        <button type="button" onClick={(e) => {
          sortByNumber();
        }}>Sort by number</button>
        <br></br>

        <button type="button" onClick={(e) => {
          sortByProviderId();
        }}>Sort by providerId</button>
       </div>
        
        <div className="table-responsive mt-5">
          <table className="table table-bordered border-dark">
            <thead>
              <tr>
                <th scope="col">Number</th>
                <th scope="col">ProviderId</th>
                <th scope="col">Date</th>
                <th scope="col">Actions</th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order) => (
                <tr key={order.Id}>
                  <th scope="row">{order.Number}</th>
                  <td>{order.ProviderId}</td>
                  <td>{order.Date}</td>
                  <td>
                    <button onClick={() => setOrderCurrentlyBeingUpdated(order)} className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                    <button onClick={() => { if (window.confirm(`Are you sure you want to delete the order with Id  "${order.Id}"?`)) deleteOrder(order.Id) }} className="btn btn-secondary btn-lg">Delete</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>

        </div>
      </>
    );
  }

  function onOrderCreated(order) {
    setShowingCreateNewOrderForm(false);

    if (order === null) {
      return;
    }


    getOrders();
  }

  function onOrderUpdated(order) {
    setOrderCurrentlyBeingUpdated(null);

    if (order === null) {
      return;
    }

    let ordersCopy = [...orders];

    const index = ordersCopy.findIndex((copyOrder, currentIndex) => {
      if (copyOrder.Id === order.Id) {
        return true;
      }
    });

    if (index !== -1) {
      ordersCopy[index] = order;
    }

    setOrders(orders);

  }

  function onOrderDeleted(deletedOrderId) {
    let ordersCopy = [...orders];

    const index = ordersCopy.findIndex((copyOrder, currentIndex) => {
      if (copyOrder.Id === deletedOrderId) {
        return true;
      }
    });

    if (index !== -1) {
      ordersCopy.splice(index, 1);
    }

    setOrders(ordersCopy);

  }
}