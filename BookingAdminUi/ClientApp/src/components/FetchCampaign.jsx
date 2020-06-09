import React from 'react';
import { Button } from 'primereact/button';
import { Growl } from 'primereact/growl';
import { Dialog } from 'primereact/dialog';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { InputSwitch } from 'primereact/inputswitch';
import { InputText } from 'primereact/inputtext';
import { ProgressSpinner } from 'primereact/progressspinner';
import { Calendar } from 'primereact/calendar';
import { InputNumber } from 'primereact/inputnumber';
import { Dropdown } from 'primereact/dropdown';
import { Messages } from 'primereact/messages';
//import { Message } from 'primereact/message';


export class FetchCampaign extends React.Component {
    static displayName = FetchCampaign.name;

    constructor(props) {
        super(props);
        this.state = {
            campaignList: [],
            loading: true,
            selectedCampaign: null,
            displayDialog: false
        };
    }

    componentDidMount() {
        this.populateCampaignData();
    }

    renderDataTable= (campaignList)=> {
        let header = <div className="p-clearfix"
                          style={{ lineHeight: '1.87em' }}>Monetary incentive campaigns
                     </div>;

        let footer = <div className="p-clearfix" style={{ width: '100%' }}>
                         <Button style={{ float: 'left' }} label="Add" icon="pi pi-plus" onClick={this.addNew}/>
                     </div>;

        return (
            <DataTable ref={(el) => this.dt = el} value={campaignList}
                       selectionMode="single"
                       header={header} footer={footer}
                       selection={this.state.selectedCampaign}
                       onSelectionChange={e => this.setState({ selectedCampaign: e.value })}
                       onRowSelect={(this.onCampaignSelect)}>
                <Column selectionMode="single" style={{ width: '3em' }}/>
                <Column field="campaignCode" header="Campaign Code"/>
                <Column field="startDate" body={this.displayStartDate} sortable header="Start Date"/>
                <Column field="endDate" body={this.displayEndDate} sortable header="End Date"/>
                <Column field="elecAmount" body={this.displayElecAmount} sortable header="Elec Amount"/>
                <Column field="gasAmount" body={this.displayGasAmount} sortable header="Gas Amount"/>
                <Column field="allCustomers" body={this.allCustomersSwitch} sortable header="All Customers"/>
                <Column field="billingSystem" sortable header="Billing System"/>
            </DataTable>
        );
    }

    renderDialog = (displayDialog) => {

        let dialogFooter = <div className="ui-dialog-buttonpane p-clearfix">
                               <Button label="Close" icon="pi pi-times" onClick={this.dialogHide} />
                               <Button label={this.newCampaign ? "Save" : "Update"} icon="pi pi-check" onClick={this.save} />
                           </div>;

        return (
            <Dialog visible={displayDialog} style={{ 'width': '380px' }}
                    header="Camapign Details" modal={true} footer={dialogFooter}
                    onHide={() => this.setState({ displayDialog: false })}>
                {
                    this.state.campaign &&

                        <div className="p-grid p-fluid">

                            <div><label htmlFor="campaigncode">Campaign Code</label></div>
                            <div>
                                <InputText id="campaigncode" onChange={(e) => { this.updateProperty('campaignCode', e.target.value) }}
                                           value={this.state.campaign.campaignCode} />
                            </div>

                            <div style={{ paddingTop: '10px' }}>
                                <label htmlFor="startDate">Start Date</label></div>
                            <div>
                                <Calendar id="startDate" showIcon={true} showTime={true} hourFormat="12" dateFormat="dd/M/yy" value={this.state.campaign.startDate === null ? null : new Date(this.state.campaign.startDate)}
                                              onChange={(e) => this.updateProperty('startDate', e.target.value)} />
                            </div>
                            <div style={{ paddingTop: '10px' }}>
                                <label htmlFor="endDate">End Date</label></div>
                            <div>
                                <Calendar id="endDate" showIcon={true} showTime={true} hourFormat="12" dateFormat="dd/M/yy" value={this.state.campaign.endDate === null ? null : new Date(this.state.campaign.endDate)}
                                                  onChange={(e) => this.updateProperty('endDate', e.target.value)} />
                            </div>

                            <div style={{ paddingTop: '10px' }}>
                                <label htmlFor="elecAmount">Elec Amount</label></div>
                            <div>
                                <InputNumber value={this.state.campaign.elecAmount} onChange={(e) => this.updateProperty('elecAmount', e.target.value)}
                                             mode="currency" currency="GBP" locale="en-GB" />
                            </div>

                            <div style={{ paddingTop: '10px' }}>
                                <label htmlFor="gasAmount">Gas Amount</label></div>
                            <div>
                                <InputNumber value={this.state.campaign.gasAmount} onChange={(e) => this.updateProperty('gasAmount', e.target.value)}
                                             mode="currency" currency="GBP" locale="en-GB" />
                            </div>

                            <div style={{ paddingTop: '10px' }}>
                                <label htmlFor="allCustomers">All Customers</label></div>
                            <div>
                                <InputSwitch checked={this.state.campaign.allCustomers} onChange={(e) => this.updateProperty('allCustomers', e.target.value)}></InputSwitch >
                            </div>

                            <div style={{ paddingTop: '10px' }}>
                                <label htmlFor="billingSystem">Billing System</label></div>
                            <div>
                                <Dropdown value={this.state.campaign.billingSystem} options={FetchCampaign.billingSystems} onChange={(e) => this.updateProperty('billingSystem', e.target.value)} placeholder="Select a Billing System" />
                            </div>
                        </div>
                }
            </Dialog>
        );
    }

    static billingSystems = [
        {label: 'Apollo', value:'Apollo'},
        {label: 'Orion', value:'Orion'}
        ];

    dialogHide = () => {
        this.newCampaign = false;
        this.setState({ displayDialog: false });
    }

    updateProperty(property, value) {
        let campaign = this.state.campaign;
        campaign[property] = value;
        this.setState({ campaign: campaign });
    }

    onCampaignSelect = (e) => {
        this.newCampaign = false;
        this.setState({
            displayDialog: true,
            campaign: Object.assign({}, e.data)
        });
    }

    displayStartDate = (rowData) => {
        return this.displayDate(rowData.startDate);
    }

    displayEndDate = (rowData) => {
        return this.displayDate(rowData.endDate);
    }

    displayDate = (dateString) => {
        return (
            <React.Fragment>
                <span style={{ verticalAlign: 'middle', marginLeft: '.5em' }}>
                    <label> {new Intl.DateTimeFormat("en-GB", {
                        year: "numeric",
                        month: "short",
                        day: "2-digit",
                        hour: "2-digit",
                        minute: "2-digit",
                        second: "2-digit"
                    }).format(new Date(dateString))} </label >
                </span>
            </React.Fragment>
        );
    }

    displayElecAmount = (rowData) => {
        return this.displayAmount(rowData.elecAmount);
    }

    displayGasAmount = (rowData) => {
        return this.displayAmount(rowData.gasAmount);
    }

    displayAmount = (amount) => {
        return (
            <React.Fragment>
                <span style={{ verticalAlign: 'middle', marginLeft: '.5em' }}>
                    <label> {new Intl.NumberFormat("en-GB", {
                        style: "currency",
                        currency: "GBP",
                        minimumFractionDigits: 0,
                        maximumFractionDigits: 0
                    }).format(amount)} </label >
                </span>
            </React.Fragment>
        );
    }

    allCustomersSwitch = (rowData) => {
        let isAllCustomerCampaign = rowData.allCustomers;
        return (
            <React.Fragment>
                <span style={{ verticalAlign: 'middle', marginLeft: '.5em' }}>
                    {<InputSwitch checked={isAllCustomerCampaign}></InputSwitch >}
                </span>
            </React.Fragment>
        );
    }

    addNew = () => {
        this.newCampaign = true;
        this.setState({
            displayDialog: true,
            campaign: { campaignCode: '', startDate: null, endDate: null, elecAmount:'', gasAmount:'', allCustomers:'', billingSystem: '' }
        });
    }

    async populateCampaignData() {
        const response = await window.fetch('campaign/api/index');
        const data = await response.json();
        this.setState({ campaignList: data, loading: false });
    }



    save = async () => {
        if (this.newCampaign) {
            const response = await window.fetch('campaign/api/Create',
                {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=UTF-8'
                    },
                    body: JSON.stringify(this.state.campaign)
                });
            this.dialogHide();
            if (response.status === 200) {
                this.setState(prevState => ({
                    campaignList: [...prevState.campaignList, this.state.campaign],
                    loading: false
                }));

                this.growl.show({
                    severity: 'success',
                    detail: "Data Saved Successfully"
                });
            } else {
                const data = await response.json();
                this.messages.show({
                    sticky: true,
                    severity: 'error',
                    summary: 'Error - Save Campaign ',
                    detail: `${data.status}: ${data.title}`
                });
            }
        } else {
            const response = await window.fetch('campaign/api/Edit',
                {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json;charset=UTF-8'
                    },
                    body: JSON.stringify(this.state.campaign)
                });
            this.dialogHide();
            if (response.status === 200) {
                const updatedCampaignList =
                    this.state.campaignList.map(obj => obj.campaignCode === this.state.campaign.campaignCode
                        ? this.state.campaign
                        : obj);
                this.setState({ campaignList: updatedCampaignList, loading: false });
                this.growl.show({
                    severity: 'success',
                    detail: "Data Updated Successfully"
                });
            } else {
                const data = await response.json();
                this.messages.show({
                    sticky: true,
                    severity: 'error',
                    summary: 'Error - Save Campaign ',
                    detail: `${data.status}: ${data.title}`
                });
            }
        }
    }

    render() {
        let contents = this.state.loading
            ? <ProgressSpinner style={{ width: '30px', height: '30px' }} strokeWidth="8" fill="#EEEEEE" animationDuration=".5s" />
            :  this.renderDataTable(this.state.campaignList);

        let dialog = this.renderDialog(this.state.displayDialog);

        return (
            <div>
                <Growl ref={(el) => this.growl = el} />
               
                <h1 id="tabelLabel" >Incentive campaign</h1>
                <p></p>
                {contents}
                {dialog}
                <div>
                    <Messages ref={(el) => this.messages = el}></Messages>
                </div>
            </div>
        );
    }
}