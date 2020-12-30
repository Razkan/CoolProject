import React from 'react';
import './style/card-area-expandable.css';
import { 
    faPlus,
    faMinus
 } from '@fortawesome/free-solid-svg-icons';
 import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class CardAreaExpandable extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            show: false
        }

        this.toggleShow = this.toggleShow.bind(this);
    }

    toggleShow = () => this.setState({show: !this.state.show});

    getButton() {
        var icon = this.state.show
            ? faMinus
            : faPlus;

        return (
            <div className="card-area-expandable-button"
                onMouseDown={this.toggleShow}>
                <FontAwesomeIcon icon={icon} />
            </div>
        );
    }

    getExpanded() {
        if (this.state.show) {
            return (
                <div className="card-area-expandable-items">
                    {this.props.children}
                </div>
            );
        }

        return null;
    }

    render() {
        return (
            <div className="card-area-expandable">
                {this.getButton()}
                {this.getExpanded()}
            </div>
        );
    }
}

export default CardAreaExpandable;
