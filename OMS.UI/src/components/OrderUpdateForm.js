import React, { useState, useEffect  } from "react"
import Select from 'react-select';
import Constants from "../utilities/Constants"

export default function OrderUpdateForm(props) {
    const initialFormData = Object.freeze({
        id: props.order.Id,
        number: props.order.Number,
        date: props.order.Date,
        providerId: props.order.ProviderId,
        orderItems: props.order.OrderItems,
    });

    const [formData, setFormData] = useState(initialFormData);
    const [number, setNumber] = useState(props.order.Number);
    const [date, setDate] = useState(new Date());
    const [providerId, setProviderId] = useState(props.order.ProviderId);
    const [providers, setProviders] = useState([]);
    const [orderItems, setOrderItems] = useState(props.order.OrderItems);

    useEffect(() => {
        tempProviders();
    }, []);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
        
    };

    const url = Constants.API_URL_GET_ALL_PROVIDERS;
    function tempProviders() {
        fetch(url, {
            method: "GET"
          })
            .then(response => response.json())
            .then(providersFromServer => {
              setProviders(providersFromServer);
              console.log(providersFromServer);
            })
            .catch((error) => {
              console.log(error);
              alert(error);
            });
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        const postToUpdate = {
            id: props.order.Id,
            number: number,
            date: date,
            providerId: providerId
        };

        const url = Constants.API_URL_UPDATE_ORDER;

        fetch(url, {
            method: "PUT",
            headers: {
                "Accept": 'application/json',
                "Content-Type": "application/json-patch+json"
            },
            body: JSON.stringify(postToUpdate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                console.log(postToUpdate);
            })
            .catch((error) => {
                console.log(error);
                console.log(postToUpdate);
                alert(error);
            });

        props.onOrderUpdated(postToUpdate);
    };

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Order information "{props.order.number}".</h1>

            <div className="mt-5">
                <label className="h3 form-label">Order Number</label>
                <input defaultValue={formData.number} name="title" type="text" className="form-control" onChange={(event) => {
                  setNumber(event.target.value);}} />

            </div>

            <div className="mt-4">
                <label className="h3 form-label">Provider ID</label>
                <Select 
                    onChange={(e) => {
                        setProviderId(e.value);
                    }} 
                    options={providers.map((el) => (
                    { 
                        label: el.Name,
                        value: el.Id
                    }))} />
            </div>

            <div className="mt-4">
            <table className="table table-bordered border-dark">
                        <thead>
                            <tr>
                            <th scope="col">item Id (PK)</th>
                            <th scope="col">item Number</th>
                            <th scope="col">quantity</th>
                            <th scope="col">unit</th>
                            </tr>
                        </thead>
                        <tbody>
                            {console.log(orderItems)}
                            {orderItems.map((item) => (
                            <tr key={item.Id}>
                                <th scope="row">{item.Name}</th>
                                <td>{item.Quantity}</td>
                                <td>{item.Unit}</td>
                                <td>
                                </td>
                            </tr>
                            ))}
                        </tbody>
                        </table>
                        </div>
            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onOrderUpdated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}