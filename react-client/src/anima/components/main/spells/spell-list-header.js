import React from 'react';
import './style/spell-list-header.css';

class SpellListHeader extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
        };

    }

    render() {
        return (
            <div className="spell-list-header-container">
                <div className="spell-list-header">
                    <div className="spell-list-header-icon"></div>
                    <div className="spell-list-header-lv">Lv</div>
                    <div className="spell-list-header-name">Name</div>
                    <div className="spell-list-header-cost">Cost</div>
                    <div className="spell-list-header-maintenance">Maintenance</div>
                    <div className="spell-list-header-type">Type</div>
                    <div className="spell-list-header-action">Action</div>
                </div>
            </div>
        );
    }
}

export default SpellListHeader;
