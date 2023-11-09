import React from "react";
import { useEffect, useState } from "react";
import axios from "axios";

const Vegtable = () => {
  const [data, setData] = useState([]);
  const fetchData = async () => {
    try {
      const response = await axios.post(
        "https://localhost:7075/api/Values/vegitable"
      );
      setData(response.data.value);
      console.log(response);
    } catch (error) {
      console.error("Error:", error);
    }
  };
  useEffect(() => {
    fetchData();
  });
  return (
    <div>
      {data.map((items) => {
        return (
          <div className="mapItems">
            <table class="table">
              <thead>
                <tr>
                  <th scope="col">Vegetable Name</th>
                  <th scope="col">Prices</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{items.vegetablesName}</td>
                  <td>Otto</td>
                </tr>
              </tbody>
            </table>
          </div>
        );
      })}
    </div>
  );
};

export default Vegtable;
