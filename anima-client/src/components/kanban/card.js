import React from 'react';
import './style/card.css';

class Card extends React.Component {

    constructor(props) {
        super(props);

        this.state = { 
            data: props.data,
        };
    }

    render() {
        
        var effectStyle = {
            display: "flex",
            flexGrow: "20",
            paddingBottom: "5px"
        }
        
        return (
            <div className="card">
                <div className="card-header card-item">
                    {this.state.data.name}
                </div>
                <div className="card-info card-item">
                    <div className="card-tag">
                        Lv: {this.state.data.level}
                    </div>
                    <div className="card-tag">
                        Cost: {this.state.data.cost}
                    </div>
                    <div className="card-tag">
                        Action: {this.state.data.action}
                    </div>
                    <div className="card-tag">
                        Type: {this.state.data.type}
                    </div>
                </div>
                <div className="card-description card-item" style={effectStyle}>
                    {this.state.data.effect}
                </div>
                <div className="card-description">
                    <div className="card-description-header">
                        <div className="card-inline-header-text">Added Effect</div>
                        <div>{this.state.data.addedEffect}</div>
                    </div>
                </div>
                <div className="card-description">
                    <div className="card-description-header">
                        <div className="card-inline-header-text">Maximum Zeon</div>
                        <div>{this.state.data.zeonAttribute} {this.state.data.maximumZeon}</div>
                    </div>
                </div>
                <div className="card-description">
                    <div className="card-description-header">
                        <div className="card-inline-header-text">Maintenance</div>
                        {this.state.data.maintenance}
                    </div>
                </div>
            </div>
        );
    }
}

export default Card;
