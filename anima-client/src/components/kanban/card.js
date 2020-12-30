import React from 'react';
import './style/card.css';
import CardArea from './card-area';
import CardAreaExpandable from './card-area-expandable';

class Card extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            data: props.data,
        };
    }

    getTags() {
        var tags = [];

        if (this.props.data.tags) {
            for (var tag of this.props.data.tags) {
                tags.push(tag);
            }
        }

        return tags.map(tag => <div key={tag} className="card-tag">{tag}</div>);
    }

    getResistance() {
        var resistances = [];

        if (this.props.data.resistances) {
            for (var resistance of this.props.data.resistances) {
                var resistanceText = resistance.type + " " + resistance.value;
                resistances.push(resistanceText);
            }
        }

        return resistances.map(resistance => <div key={resistance} className="card-tag">{resistance}</div>);
    }

    render() {
        return (
            <div className="card">

                <CardArea header={this.state.data.name}>
                    <div className="card-info">
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
                </CardArea>

                <CardArea>
                    <div className="card-description">
                        {this.props.data.effect}
                    </div>
                </CardArea>

                <CardAreaExpandable>

                    <CardArea>
                        <div className="slotted-card-header">
                            Added Effect
                        </div>
                        <div className="card-description">
                            {this.props.data.addedEffect}
                        </div>
                    </CardArea>

                    <div className="slotted-card-additional-info">
                        <CardArea>
                            <div className="card-info card-info-slotted">
                                <div className="slotted-card-header">
                                    Maintenance
                                </div>
                                <div className="card-tag">
                                    {this.state.data.maintenanceDuration}
                                </div>
                            </div>
                            <div className="card-description">
                                {this.props.data.maintenance}
                            </div>

                        </CardArea>

                        <CardArea>
                            <div className="card-info card-info-slotted">
                                <div className="slotted-card-header">
                                    Maximum Zeon
                                </div>
                                <div className="card-tag">
                                    {this.state.data.zeonAttribute}
                                </div>
                            </div>
                            <div className="card-description">
                                {this.props.data.maximumZeon}
                            </div>
                        </CardArea>
                    </div>

                    <div className="slotted-card-additional-info">
                        <CardArea>
                            <div className="slotted-card-header">Tags</div>
                            <div className="card-info">
                                {this.getTags()}
                            </div>
                        </CardArea>

                        <CardArea>
                            <div className="slotted-card-header">Resistances</div>
                            <div className="card-info">
                                {this.getResistance()}
                            </div>
                        </CardArea>
                    </div>

                    {/* <CardArea>
                        <div className="slotted-card-header">Tags</div>
                        <div className="card-info">
                            {this.getTags()}
                        </div>
                    </CardArea> */}

                </CardAreaExpandable>

            </div>
        );
    }

    // render() {

    //     var effectStyle = {
    //         display: "flex",
    //         flexGrow: "20",
    //         paddingBottom: "5px"
    //     }

    //     return (
    //         <div className="card">
    //             <div className="card-header card-item">
    //                 {this.state.data.name}
    //             </div>
    //             <div className="card-info card-item">
    // <div className="card-tag">
    //     Lv: {this.state.data.level}
    // </div>
    // <div className="card-tag">
    //     Cost: {this.state.data.cost}
    // </div>
    // <div className="card-tag">
    //     Action: {this.state.data.action}
    // </div>
    // <div className="card-tag">
    //     Type: {this.state.data.type}
    // </div>
    //             </div>
    //             <div className="card-description card-item" style={effectStyle}>
    //                 {this.state.data.effect}
    //             </div>
    //             <div className="card-description">
    //                 <div className="card-description-header">
    //                     <div className="card-inline-header-text">Added Effect</div>
    //                     <div>{this.state.data.addedEffect}</div>
    //                 </div>
    //             </div>
    //             <div className="card-description">
    //                 <div className="card-description-header">
    //                     <div className="card-inline-header-text">Maximum Zeon</div>
    //                     <div>{this.state.data.zeonAttribute} {this.state.data.maximumZeon}</div>
    //                 </div>
    //             </div>
    //             <div className="card-description">
    //                 <div className="card-description-header">
    //                     <div className="card-inline-header-text">Maintenance</div>
    //                     {this.state.data.maintenance}
    //                 </div>
    //             </div>
    //         </div>
    //     );
    // }
}

export default Card;
