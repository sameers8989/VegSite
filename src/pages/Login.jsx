import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Login.css";
import { Link } from "react-router-dom";

const Login = () => {
  const [datas, setDatas] = useState([]);

  const fetchData = async () => {
    try {
      const response = await axios.get(
        "https://localhost:7075/api/work/verify"
      );
      setDatas(response.data.value);
      console.log(response);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <div>
      <div className="container-fluid px-1 px-md-5 px-lg-1 px-xl-5 py-5 mx-auto">
        <div className="card card0 border-0">
          <div className="row d-flex">
            <div className="col-lg-6">
              <div className="card1 pb-5">
                <div className="row">
                  <img src="https://i.imgur.com/CXQmsmF.png" className="logo" />
                </div>
                <div className="row px-3 justify-content-center mt-4 mb-5 border-line">
                  <img
                    src="https://i.imgur.com/uNGdWHi.png"
                    className="image"
                  />
                </div>
              </div>
            </div>
            <div className="col-lg-6">
              <div className="card2 card border-0 px-4 py-5">
                <div className="row px-3">
                  <label className="mb-1">
                    <h6 className="mb-0 text-sm">Email Address</h6>
                  </label>
                  <input
                    className="mb-4"
                    type="text"
                    name="email"
                    placeholder="Enter a valid email address"
                  />
                </div>
                <div className="row px-3">
                  <label className="mb-1">
                    <h6 className="mb-0 text-sm">Password</h6>
                  </label>
                  <input
                    type="password"
                    name="password"
                    placeholder="Enter password"
                  />
                </div>
                <div className="px-3 mb-4 d-flex justify-content-between">
                  <div className="custom-control custom-checkbox custom-control-inline d-flex">
                    <div className="custom">
                      <input
                        id="chk1"
                        type="checkbox"
                        name="chk"
                        className="custom-control-input"
                      />
                      <label
                        for="chk1"
                        className="custom-control-label text-sm"
                      >
                        Remember me
                      </label>
                    </div>
                  </div>
                  <a href="#" className="ml-auto mb-0 text-sm">
                    Forgot Password?
                  </a>
                </div>
                <div className="row mb-3 px-3">
                  <Link to="/vegtable">
                    <button type="submit" className="btn btn-blue text-center">
                      Login
                    </button>
                  </Link>
                </div>
                <div className="row mb-4 px-3">
                  <small className="font-weight-bold">
                    Don't have an account?{" "}
                    <a className="text-danger ">Register</a>
                  </small>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
