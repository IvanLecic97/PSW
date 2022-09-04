import React, { useState } from "react";
import { Form, FormGroup } from "react-bootstrap";
import axios from "axios";
import { Navigate, useNavigate } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  let navigate = useNavigate();

  let onSubmit = (event) => {
    event.preventDefault();
    const url = "http://localhost:56210/login";
    const data = {
      Email: email,
      Password: password,
    };

    axios.post(url, data).then((response) => {
      console.log(response.data.token);
      console.log(response.data.role);
      console.log(response.data.email);
      localStorage.setItem("token", response.data.token);
      localStorage.setItem("email", response.data.email);
      localStorage.setItem("role", response.data.roles);
    });
    if (localStorage.getItem("role") == "Patient") {
      navigate("/patientHomepage");
    } else if (localStorage.getItem("role") == "Doctor") {
      navigate("/doctorHomepage");
    }
  };

  return (
    <div>
      <Form style={{ width: "250px" }} onSubmit={onSubmit}>
        <FormGroup>
          <input
            onChange={(event) => setEmail(event.target.value)}
            placeholder="Email"
            name="email"
            className="form-control"
            type="text"
          />
        </FormGroup>
        <FormGroup>
          <input
            onChange={(event) => setPassword(event.target.value)}
            placeholder="Password"
            name="password"
            type="text"
            className="form-control"
          />
        </FormGroup>
        <FormGroup>
          <button type="submit">Submit</button>
        </FormGroup>
      </Form>
    </div>
  );
};

export default Login;
