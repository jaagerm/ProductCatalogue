import * as React from 'react';
import { TextField, MessageBarType, DefaultButton } from 'office-ui-fabric-react';
import { MessageBarWrapper } from './MessageBarWrapper';
import * as DataSender from '../../services/data-service';

interface IContentState {
    errorMessage: string;
    errorMessageId: number;
    successMessage: string;
    successMessageId: number;
}

export class Content extends React.Component<any, IContentState> {
    private employeeId: string = '';

    constructor(props, context) {
        super(props, context)

        this.state = {
            errorMessage: '',
            errorMessageId: 0,
            successMessage: '',
            successMessageId: 0
        };
    }

    render() {
        return (
            <div className='ms-Grid' dir='ltr' style={{padding: 20}}>
                <div className='ms-Grid-row'>
                    <div className='ms-Grid-col ms-sm9' style={{padding: 5}}>
                        <TextField
                            label='Employee ID:'
                            underlined
                            disabled = {false}
                            onChange = {(_, newValue: string) => this.onEmployeeIdChange(newValue)}/>
                    </div>
                </div>

                <div className='ms-Grid-row' style={{padding: 5, paddingTop: 10}}>

                <DefaultButton
                    className={"ms-Grid-col ms-sm5"}
                    text='Send Data'
                    onClick={this.onSendData} />

                </div>
                <div className='ms-Grid-row'>
                    <div style={{paddingTop: 5}}>
                        <MessageBarWrapper
                            messageBarType={MessageBarType.success}
                            truncated={false}
                            autoDismiss={true}
                            message={this.state.successMessage}
                            messageId={this.state.successMessageId}/>
                        <MessageBarWrapper
                            messageBarType={MessageBarType.error}
                            truncated={true}
                            autoDismiss={false}
                            message={this.state.errorMessage}
                            messageId={this.state.errorMessageId}/>
                    </div>
                </div>
            </div>
        );
    }

    private onSendData = async () => {
        try {
            await DataSender.sendData(
                this.employeeId,
                this.sendDataMessageCallbackImplementation);
        } catch (error) {
            this.showErrorMessage('Exception thrown when sending data! ' + error);
        }
    }

    private sendDataMessageCallbackImplementation = (message: string) => {
        this.showSuccessMessage(message);
    }

    private showSuccessMessage = (message: string) => {
        this.setState({
            successMessage: message,
            successMessageId: this.state.successMessageId + 1
        });
    }

    private showErrorMessage = (message: string) => {
        this.setState({
            errorMessage: message,
            errorMessageId: this.state.errorMessageId + 1
        });
    }

    private onEmployeeIdChange = (newValue: string) => {
        this.employeeId = newValue.trim();
    }
}