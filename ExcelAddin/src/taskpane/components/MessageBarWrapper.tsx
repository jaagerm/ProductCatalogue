import * as React from 'react';
import { MessageBar, MessageBarType } from 'office-ui-fabric-react';

export interface IMessageBarWrapperProps {
    message: string;
    messageId: number;
    messageBarType: MessageBarType;
    truncated: boolean;
    autoDismiss: boolean;
}

export class MessageBarWrapper extends React.Component<IMessageBarWrapperProps, any> {
    private hideMessageCommandGiven = false;
    private hideMessageTimeout: any;

    constructor(props, context) {
        super(props, context);

        this.runHideMessageTimeout = this.runHideMessageTimeout.bind(this);
        this.initiateHideMessage = this.initiateHideMessage.bind(this);
    }

    render() {
        const messageBar = (
            <div style={{paddingTop: 10}}>
                <MessageBar
                        messageBarType={this.props.messageBarType}
                        truncated={this.props.truncated}
                        onDismiss={this.initiateHideMessage}
                        isMultiline={false}>
                    {this.props.message}
                </MessageBar>
            </div>
        );

        return this.hideMessageCommandGiven || !this.props.message 
            ? <div></div>
            : messageBar;
    }

    shouldComponentUpdate(nextProps: IMessageBarWrapperProps) {
        if (nextProps.messageId !== this.props.messageId
                || this.hideMessageCommandGiven) {

            return true;
        }

        return false;
    }

    componentDidUpdate(prevProps: IMessageBarWrapperProps) {
        if (this.props.autoDismiss
                && prevProps.messageId !== this.props.messageId) {
            this.runHideMessageTimeout();
        }

        if (this.hideMessageCommandGiven) {
            this.hideMessageCommandGiven = false;
        }
    }

    private runHideMessageTimeout() {
        if (this.hideMessageTimeout) {
            clearTimeout(this.hideMessageTimeout);
        }
        this.hideMessageTimeout = setTimeout(this.initiateHideMessage, 3000);
    }

    private initiateHideMessage() {
        this.hideMessageCommandGiven = true;
        this.setState({});
    }
}