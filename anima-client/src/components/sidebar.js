import React from 'react';
import './style/sidebar.css';
import SidebarItem from './sidebar-item';
import {
    faUser,
    faBookOpen,
    faStickyNote
} from '@fortawesome/free-solid-svg-icons';
import { connect } from 'react-redux';

const mapDispatchToProps = dispatch => ({ dispatch });

class Sidebar extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            show: false,
            activeItem: "Spells"
        };

        this.props.dispatch({ type: "sidebar", sidebar: this.state.activeItem });
    }

    open = () => this.setState({ show: true });
    close = () => this.setState({ show: false });

    itemSelected = value => this.setState({ activeItem: value }, () => this.props.dispatch({ type: "sidebar", sidebar: value }));

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
        var items = [
            <SidebarItem key={0}
                icon={faUser}
                text={"Character"}
                show={() => this.state.show}
                active={this.state.activeItem}
                onSelect={this.itemSelected} />,

            <SidebarItem key={1}
                icon={faBookOpen}
                text={"Spells"}
                show={() => this.state.show}
                active={this.state.activeItem}
                onSelect={this.itemSelected} />,

            <SidebarItem key={2}
                icon={faStickyNote}
                text={"Notes"}
                show={() => this.state.show}
                active={this.state.activeItem}
                onSelect={this.itemSelected} />,
        ];
        return items
    }
}

export default connect(null, mapDispatchToProps)(Sidebar);
