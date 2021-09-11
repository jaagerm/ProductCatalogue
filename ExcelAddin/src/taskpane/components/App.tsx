import * as React from "react";
import Progress from "./Progress";
import { Content } from "./Content";

export interface IAppProps {
  title: string;
  isOfficeInitialized: boolean;
}

export default class App extends React.Component<IAppProps> {
  constructor(props, context) {
    super(props, context);
  }

  render() {
    const { title, isOfficeInitialized } = this.props;

    if (!isOfficeInitialized) {
      return (
          <Progress title={title} logo="assets/logo-filled.png" message="Please sideload your addin to see app body." />
      );
    }

    return (
      <div className='ms-welcome'>
          <Content/>
      </div>
    );
  }
}
