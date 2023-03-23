import React, { useState, useEffect } from "react"
import Constants from "../utilities/Constants"
import Select from 'react-select';
import 'bootstrap/dist/css/bootstrap.min.css';


export default function OrderCreateForm(props) {    
    const initialFormData = Object.freeze({
        number: "X",
        providerId: 2
    });
    const [formData, setFormData] = useState(initialFormData);
    const [number, setNumber] = useState("");
    const [date, setDate] = useState(new Date());
    const [providerId, setProviderId] = useState("");
    const [providers, setProviders] = useState([]);

    useEffect(() => {
        tempProviders();
    }, []);
    
    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };


    const handleSubmit = (e) => {
        e.preventDefault();

        const orderToCreate = {
            number: number,
            date: date,
            providerId: providerId
        };

        const url = Constants.API_URL_CREATE_ORDER;
        
        fetch(url, {
            method: "POST",
            headers: {
                "Accept": 'application/json',
                "Content-Type": "application/json-patch+json"
            },
            body: JSON.stringify(orderToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                console.log(JSON.stringify(orderToCreate))
            })
            .catch((error) => {
                alert("invalid number!");
                console.log(error);
                console.log(orderToCreate)
            });

        props.onOrderCreated(orderToCreate);
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
        
    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new Order</h1>

            <div className="mt-5">
                <label className="h3 form-label">Order Number</label>
                <input defaultValue={number} name="title" type="text" className="form-control" onChange={(event) => {
                  setNumber(event.target.value);}} />
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Provider</label>
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

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onOrderCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}
