import React from 'react';
import './style/core-spell.css';
import Text from '../../../redux/highlight/text';

class CoreSpell extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            data: props.data,
            show: false,
            isHighlight: false,
            hasHighlight: false,
            inView: false
        };
    }

    toggleShow = () => this.setState({ show: !this.state.show });

    onHighlight = (isHighlight, hasHighlight) => this.setState({ isHighlight, hasHighlight });

    inViewChanged = (inView, entry) => this.setState({ inView })

    getTags() {
        var tags = [];

        if (this.props.data.tags) {
            for (var tag of this.props.data.tags) {
                tags.push(tag);
            }
        }

        return tags.map(tag => <div key={tag} className="core-spell-tag">{tag}</div>);
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
        var classes = ["core-spell-expandable-item"];

        if (!this.state.show && !this.state.hasHighlight) {
            classes.push("core-spell-expandable-item-hidden");
        }

        return classes.join(" ");
    }

    getExpanded() {
        return (
            <div className={this.getExpandedClass()}>
                <div className="core-spell-expandable-item-section1">
                    <div className="core-spell-expandable-item-section1-column">
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Level
                                </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.props.data.level}
                            </div>
                        </div>
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                School
                            </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.props.school}
                            </div>
                        </div>
                    </div>
                    <div className="core-spell-expandable-item-section1-column">
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Cost
                                </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.props.data.cost}
                            </div>
                        </div>
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Resistance(s)
                            </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.getResistance()}
                            </div>

                        </div>
                    </div>
                    <div className="core-spell-expandable-item-section1-column">
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Maximum Zeon
                            </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.props.data.zeonAttribute} {this.props.data.maximumZeon}
                            </div>
                        </div>
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Action
                                </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.props.data.action}
                            </div>
                        </div>
                    </div>
                    <div className="core-spell-expandable-item-section1-column">
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Maintenance
                                </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.props.data.maintenance}
                            </div>

                        </div>
                        <div>
                            <div className="core-spell-expandable-item-section1-column-header">
                                Type
                                </div>
                            <div className="core-spell-expandable-item-section1-column-value">
                                {this.getType()}
                            </div>
                        </div>
                    </div>
                </div>
                <div className="core-spell-expandable-item-breakline" />
                <div className="core-spell-expandable-item-section2">
                    <div className="core-spell-expandable-item-section2-effect">
                        <strong>Effect:</strong> <Text value={this.props.data.effect} onHighlight={this.onHighlight} />
                    </div>
                    <div className="core-spell-expandable-item-section2-added-effect">
                        <strong>Added Effect:</strong> {this.props.data.addedEffect}
                    </div>
                </div>
                <div className="core-spell-expandable-item-section3">
                    <div>Tags:</div> {this.getTags()}
                </div>
            </div>
        );
    }

    getCoreSpellClasses() {
        var classes = ["core-spell"];

        if (this.state.isHighlight && !this.state.hasHighlight) {
            classes.push("core-spell-hidden");
        }

        return classes.join(" ")
    }

    render() {
        return (

            <div className={this.getCoreSpellClasses()}>
                <div className="core-spell-header"
                    onMouseDown={this.toggleShow}
                >
                    <div className={"core-spell-header-icon core-spell-icon-" + this.props.school.toLowerCase()} />

                    <div className="core-spell-header-lv">
                        {this.props.data.level}
                    </div>

                    <div className="core-spell-header-name-container">
                        <div className="core-spell-header-name">{this.props.data.name}</div>
                        <div className="core-spell-header-school">{this.props.school}</div>
                    </div>

                    <div className="core-spell-header-cost">
                        {this.props.data.cost}
                    </div>

                    <div className="core-spell-header-maintenance">
                        {this.props.data.maintenanceDuration}
                    </div>

                    <div className="core-spell-header-type">
                        {this.getType()}
                    </div>

                    <div className="core-spell-header-action">
                        {this.props.data.action}
                    </div>
                </div>

                {this.getExpanded()}
            </div>
        );
    }
}

export default CoreSpell;
