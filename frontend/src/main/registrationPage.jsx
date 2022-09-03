import React, { useState } from "react";
import { Form, FormGroup } from "react-bootstrap";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import axios from "axios";

const RegistrationPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [phone, setPhone] = useState("");
  const [address, setAddress] = useState("");
  const [city, setCity] = useState("");
  const [birthday, setBirthday] = useState(new Date());
  const [bloodType, setBloodType] = useState("");
  const [healthCard, setHealthCard] = useState("");
  const [isBlocked, setIsBlocked] = useState(false);
  const [isBlockable, setIsBlockable] = useState(false);

  let onSubmit = (event) => {
    event.preventDefault();
    const url = "http://localhost:56210/patients/register";
    const data = {
      email: email,
      password: password,
      name: name,
      surname: surname,
      phone: phone,
      address: address,
      city: city,
      birthday: birthday,
      bloodType: bloodType,
      healthCard: healthCard,
      isBlocked: isBlocked,
      isBlockable: isBlockable,
    };

    axios.post(url, data);
  };

  let onChange = (event) => {
    event.preventDefault();
    setEmail(event.target.value);
    console.log(email);
  };

  return (
    <div>
      <Form style={{ width: "350px" }} onSubmit={onSubmit}>
        <FormGroup>
          <input
            onChange={(event) => setEmail(event.target.value)}
            placeholder="Username"
            name="email"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setPassword(event.target.value)}
            placeholder="Password"
            name="password"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setName(event.target.value)}
            placeholder="Name"
            name="name"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setSurname(event.target.value)}
            placeholder="Surname"
            name="surname"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setPhone(event.target.value)}
            placeholder="Phone number"
            name="phone"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setAddress(event.target.value)}
            placeholder="Address"
            name="address"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setCity(event.target.value)}
            placeholder="City"
            name="city"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <DatePicker
            selected={birthday}
            onChange={(date) => setBirthday(date)}
            dateFormat="yyyy/MM/dd"
          />
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setBloodType(event.target.value)}
            placeholder="Blood type"
            name="bloodType"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setHealthCard(event.target.value)}
            placeholder="Health card number"
            name="healthCard"
            type="text"
            className="form-control"
          ></input>
        </FormGroup>
        <FormGroup>
          <button type="submit">submit</button>
        </FormGroup>
      </Form>
    </div>
  );
};

export default RegistrationPage;
