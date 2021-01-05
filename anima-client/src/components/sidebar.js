import React from 'react';
import './style/sidebar.css';
import SidebarItem from './sidebar-item';
import { 
    faUser,
    faBookOpen,
    faStickyNote
 } from '@fortawesome/free-solid-svg-icons'

class Sidebar extends React.Component {

    constructor(props) {
        super(props);

        this.state = {show: false};
    }

    open = () => this.setState({show: true});
    close = () => this.setState({show: false});

    getSidebarClass() {
        var classes = ["sidebar"];

        if(!this.state.show) {
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
            <SidebarItem key={0} icon={faUser} text={"Character"} show={() => this.state.show} default={false}/>,
            <SidebarItem key={1} icon={faBookOpen} text={"Spells"} show={() => this.state.show} default={true}/>,
            <SidebarItem key={2} icon={faStickyNote} text={"Notes"} show={() => this.state.show} default={false}/>,
        ];
        return items
    }
}

export default Sidebar;
