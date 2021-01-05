import React from 'react';
import './style/card.css';
import Text from '../../redux/highlight/text';

class Card extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            data: props.data,
            show: false
        };
    }

    toggleShow = () => this.setState({ show: !this.state.show });
    hasHighlight = highlight => this.setState({ show: highlight });

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

        if (resistances.length === 0) {
            return (
                <div>
                    None
                </div>
            );
        }
        return resistances.map(resistance => <div key={resistance}>{resistance}</div>);
    }

    getType() {
        if (this.props.data.type.length === 0) {
            return (
                <div>
                    None
                </div>
            );
        }
        return this.props.data.type.map(type => <div key={type}>{type}</div>);
    }

    getExpandedClass() {
        var classes = ["card-expandable-item"];

        if (!this.state.show) {
            classes.push("card-expandable-item-hidden");
        }

        return classes.join(" ");
    }

    getExpanded() {
        return (
            <div className={this.getExpandedClass()}>
                <div className="card-expandable-item-section1">
                    <div className="card-expandable-item-section1-column">
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Level
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.props.data.level}
                            </div>
                        </div>
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Type
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.getType()}
                            </div>
                        </div>
                    </div>
                    <div className="card-expandable-item-section1-column">
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Cost
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.props.data.cost}
                            </div>
                        </div>
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Action
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.props.data.action}
                            </div>
                        </div>
                    </div>
                    <div className="card-expandable-item-section1-column">
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Maximum Zeon
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.props.data.zeonAttribute} {this.props.data.maximumZeon}
                            </div>
                        </div>
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Maintenance
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.props.data.maintenance}
                            </div>
                        </div>
                    </div>
                    <div className="card-expandable-item-section1-column">
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Resistance(s)
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                {this.getResistance()}
                            </div>
                        </div>
                        <div>
                            <div className="card-expandable-item-section1-column-header">
                                Placeholder
                                </div>
                            <div className="card-expandable-item-section1-column-value">
                                Value
                                </div>
                        </div>
                    </div>
                </div>
                <div className="card-expandable-item-breakline" />
                <div className="card-expandable-item-section2">
                    <div className="card-expandable-item-section2-effect">
                        <strong>Effect:</strong> <Text value={this.props.data.effect} hasHighlight={this.hasHighlight} />
                    </div>
                    <div className="card-expandable-item-section2-added-effect">
                        <strong>Added Effect:</strong> {this.props.data.addedEffect}
                    </div>
                </div>
                <div className="card-expandable-item-section3">
                    <strong>Tags: </strong>
                </div>
            </div>
        );

    }

    render() {
        return (
            <div className="card">
                <div className="card-header"
                    onMouseDown={this.toggleShow}
                >
                    <div className={"card-header-icon card-icon-" + this.props.school.toLowerCase()} />

                    <div className="card-header-lv">
                        {this.props.data.level}
                    </div>

                    <div className="card-header-name-container">
                        <div className="card-header-name">{this.props.data.name}</div>
                        <div className="card-header-school">{this.props.school}</div>
                    </div>

                    <div className="card-header-cost">
                        {this.props.data.cost}
                    </div>

                    <div className="card-header-maintenance">
                        {this.props.data.maintenanceDuration}
                    </div>

                    <div className="card-header-type">
                        {this.getType()}
                    </div>

                    <div className="card-header-action">
                        {this.props.data.action}
                    </div>
                </div>

                {this.getExpanded()}
            </div>
        );
    }
}

export default Card;
