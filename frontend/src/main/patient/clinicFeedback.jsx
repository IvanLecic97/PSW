import React, { useEffect, useState } from "react";
import axios from "axios";

function ClinicFeedback() {
  const token = localStorage.getItem("token");
  const email = localStorage.getItem("email");

  const [rating, setRating] = useState(null);
  const [feedback, setFeedback] = useState("");
  const [anonymous, setAnonymous] = useState(false);

  const onChangeRating = (event) => {
    setRating(event.target.value);
  };

  const onFeedbackChange = (event) => {
    setFeedback(event.target.value);
  };

  const onAnonymousChange = () => {
    setAnonymous(!anonymous);
  };

  const onSendClick = (event) => {
    event.preventDefault();
    const url = "http://localhost:56210/patients/addClinicFeedback";
    const data = {
      text: feedback,
      rating: rating,
      anonymous: anonymous,
      patientUsername: email,
    };

    axios
      .post(url, data, { headers: { Authorization: `Bearer ${token}` } })
      .then((res) => console.log(res.data));
  };

  return (
    <div>
      <textarea onChange={onFeedbackChange} placeholder="Clinic feedback" />
      <br />
      <br />
      <input
        type="number"
        placeholder="Clinic rate(1-10)"
        onChange={onChangeRating}
      />
      <br />
      <br />
      <input type="checkbox" onChangeonAnonymousChange />
      <label>Anonymous rating</label>
      <br />
      <br />
      <button onClick={onSendClick}>Send feedback</button>
    </div>
  );
}

export default ClinicFeedback;
