import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <div>
              <h1>Smart Booking Application Management</h1>
              <p>This application is home to managing configurations that control aspects of the smart meter booking journey</p>
              <p>Following features can be managed using this application</p>

              <ul>
                  <li><a href="/fetch-campaign">Monetary Incentive Campaigns</a></li>
              </ul>
          </div>
      );
  }
}
