import React, { useState, useEffect } from "react";
import axios from "axios";
import Table from "react-bootstrap/Table";

function AllFeedbacks() {
  const token = localStorage.getItem("token");

  const [loadedData, setLoadedData] = useState([]);

  const loadData = async () => {
    const url = "http://localhost:56210/feedback/all";
    try {
      const data = await fetch(url, {
        headers: { Authorization: `Bearer ${token}` },
      });
      const data1 = await data.json();
      console.log(data1);
      setLoadedData(data1.feedbacks);
    } catch (error) {
      console.log("error", error);
    }
  };

  function checkState(value) {
    if (value) {
      return "Yes";
    } else return "No";
  }

  function changeApproval(value) {
    if (value) {
      return "Disapprove";
    } else return "Approve";
  }

  function onApprovalClick(event, id, approval) {
    event.preventDefault();
    const url = "http://localhost:56210/feedback/approval";
    const data = {
      adminApproval: !approval,
      id: id,
    };

    axios
      .post(url, data, {
        headers: { Authorization: `Bearer ${token}` },
      })
      .then((res) => window.alert(res.data.response));
  }

  const table = (
    <Table>
      <thead>
        <th>#</th>
        <th>Rating</th>
        <th>Comment</th>
        <th>Approved</th>
        <th>Change approval</th>
      </thead>
      <tbody>
        {loadedData.map((value) => (
          <tr key={value.id}>
            <th></th>
            <th>{value.rating}</th>
            <th>{value.text}</th>
            <th>{checkState(value.adminApproval)}</th>
            <th>
              <button
                onClick={(event) =>
                  onApprovalClick(event, value.id, value.adminApproval)
                }
              >
                {changeApproval(value.adminApproval)}
              </button>
            </th>
          </tr>
        ))}
      </tbody>
    </Table>
  );

  useEffect(() => {
    loadData();
  }, []);

  return <div style={{ backgroundColor: "aquamarine" }}>{table}</div>;
}

export default AllFeedbacks;
