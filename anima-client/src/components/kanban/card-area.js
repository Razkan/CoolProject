import React from 'react';
import './style/card-area.css';

class CardArea extends React.Component {

    constructor(props) {
        super(props);
    }

    getHeader() {
        if(this.props.header) {
            return (
                <div className="card-area-header">
                    {this.props.header}
                </div>
            );
        }
        return null;
    }

    render() {
        return (
            <div className="card-area">
                {this.getHeader()}
                {this.props.children}
            </div>
        );
    }
}

export default CardArea;
