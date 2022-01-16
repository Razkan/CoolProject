import React from 'react';
import './style/sidebar-item.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { 
    Link,
    withRouter 
} from 'react-router-dom';

class SidebarItem extends React.Component {

    isActive() {
        return ("/" + this.props.text) === this.props.active;
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

        const { url } = this.props.match;

        return (
            <Link to={url + "/" + this.props.text}>
                <div className={this.getStyle()}>
                    {this.getContent()}
                </div>
            </Link>
        );
    }
}

export default withRouter(SidebarItem);
