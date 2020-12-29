import React from 'react';
import './style/sidebar-item.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class SidebarItem extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            icon: props.icon,
            text: props.text,
            show: props.show,
            active: props.default
        };
    }

    getStyle() {
        var style = ["sidebar-item"];

        if (this.state.show()) {
            style.push("sidebar-item-expanded");
        }
        else {
            style.push("sidebar-item-collapsed");
        }

        if (this.state.active) {
            style.push("sidebar-item-active");
        }

        return style.join(" ");
    }

    render() {
        if (this.state.show()) {
            return (
                <div className={this.getStyle()}>
                    {this.state.text}
                </div>
            );
        }
        else {
            return (
                <div className={this.getStyle()}>
                    <FontAwesomeIcon icon={this.state.icon} />
                </div>
            );
        }
    }
}

export default SidebarItem;
