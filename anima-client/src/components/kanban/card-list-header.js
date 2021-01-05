import React from 'react';
import './style/card-list-header.css';

class CardListHeader extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
        };

    }

    render() {
        return (
            <div className="card-list-header-container">
                <div className="card-list-header">
                    <div className="card-list-header-icon"></div>
                    <div className="card-list-header-lv">Lv</div>
                    <div className="card-list-header-name">Name</div>
                    <div className="card-list-header-cost">Cost</div>
                    <div className="card-list-header-maintenance">Maintenance</div>
                    <div className="card-list-header-type">Type</div>
                    <div className="card-list-header-action">Action</div>
                </div>
            </div>
        );
    }
}

export default CardListHeader;
