import React from 'react';
import './style/action-button.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class ActionButton extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        var backgroundColor = this.props.active
            ? "gray"
            : "#424B54";

        var buttonStyle = {
            backgroundColor: backgroundColor
        }

        return (
            <div className="action-button">
                <button className="action-button-button"
                    style={buttonStyle}
                    onMouseDown={this.props.onClick}>
                    <div>
                        <FontAwesomeIcon icon={this.props.icon} />
                        {this.props.text}
                    </div>
                </button>
            </div>
        );
    }
}

export default ActionButton;
