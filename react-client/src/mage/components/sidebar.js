import React from 'react';
import './style/sidebar.css';
import SidebarItem from './../../shared/pages/sidebar-item';

import {
    faUser,
    faBookOpen,
    faStickyNote,
} from '@fortawesome/free-solid-svg-icons';
import { withRouter } from 'react-router-dom';

class Sidebar extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            show: false
        };
    }

    open = () => this.setState({ show: true });
    close = () => this.setState({ show: false });

    getSidebarClass() {
        var classes = ["sidebar"];

        if (!this.state.show) {
            classes.push("sidebar-collapsed");
        }

        return classes.join(" ");
    }

    render() {
        return (
            <div className={this.getSidebarClass()}
                onMouseDown={this.open}
                onMouseLeave={this.close}
            >
                {this.getItems()}
            </div>
        );
    }

    getItems() {
        var key = 0;

        var items = [
            <SidebarItem key={key++}
                icon={faUser}
                text={"Character"}
                show={() => this.state.show}
                active={this.props.location.pathname} />,

            <SidebarItem key={key++}
                icon={faBookOpen}
                text={"Spells"}
                show={() => this.state.show}
                active={this.props.location.pathname} />,

            <SidebarItem key={key++}
                icon={faStickyNote}
                text={"Notes"}
                show={() => this.state.show}
                active={this.props.location.pathname} />,
        ];
        return items
    }
}

export default withRouter(Sidebar);
