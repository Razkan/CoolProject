import React from 'react';
import './style/button-menu.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class ButtonMenu extends React.Component {

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
            <div className="button-menu">
                <button className="button-menu-button"
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

export default ButtonMenu;
