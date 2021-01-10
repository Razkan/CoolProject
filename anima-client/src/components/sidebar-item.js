import React from 'react';
import './style/sidebar-item.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class SidebarItem extends React.Component {

    isActive() {
        return this.props.text === this.props.active;
    }

    getStyle() {
        var style = ["sidebar-item"];

        if (this.props.show()) {
            style.push("sidebar-item-expanded");
        }
        else {
            style.push("sidebar-item-collapsed");
        }

        if (this.isActive()) {
            style.push("sidebar-item-active");
        }

        return style.join(" ");
    }

    getContent() {
        if (this.props.show()) {
            return this.props.text
        }

        return (<FontAwesomeIcon icon={this.props.icon} />);
    }

    render() {

        return (
            <div className={this.getStyle()}
                onMouseDown={() => this.props.onSelect(this.props.text)}>
                {this.getContent()}
            </div>
        );
    }
}

export default SidebarItem;
