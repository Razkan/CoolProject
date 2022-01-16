import React from 'react';
import './style/arcanum-spell.css';
import Text from './../../../../shared/redux/highlight/text';

class ArcanumSpell extends React.Component {

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

        return tags.map(tag => <div key={tag} className="arcanum-spell-tag">{tag}</div>);
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
        if (!this.props.data.type || this.props.data.type.length === 0) {
            return (
                <div>
                    None
                </div>
            );
        }
        return this.props.data.type.map(type => <div key={type}>{type}</div>);
    }

    getReachEffect() {
        return (
            <div className="arcanum-spell-container">
                {<div>{this.props.data.reachEffects.map((obj, i) => <div key={i}><strong>+{obj.reach}: </strong>{obj.effect}</div>)}</div>}                
            </div>
        );
    }

    getSchoolEffect() {
        return (
            <div className="arcanum-spell-container">
                {<div>{this.props.data.schoolEffects.map((obj, i) => <div key={i}><strong>Add {obj.school} (**): </strong>{obj.effect}</div>)}</div>}                
            </div>
        );
    }

    getExpandedClasses() {
        var classes = ["arcanum-spell-expandable-item"];

        if (!this.state.show && !this.state.hasHighlight) {
            classes.push("arcanum-spell-expandable-item-hidden");
        }

        return classes.join(" ");
    }

    getExpanded() {
        return (
            <div className={this.getExpandedClasses()}>
                <div className="arcanum-spell-expandable-item-section1">
                    <div className="arcanum-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Level
                                </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.props.data.level}
                            </div>
                        </div>
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                School
                            </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.props.school}
                            </div>
                        </div>
                    </div>
                    <div className="arcanum-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Cost
                                </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                -
                            </div>
                        </div>
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Resistance(s)
                            </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.getResistance()}
                            </div>

                        </div>
                    </div>
                    <div className="arcanum-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Maximum Zeon
                            </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.props.data.zeonAttribute} {this.props.data.maximumZeon}
                            </div>
                        </div>
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Action
                                </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.props.data.action}
                            </div>
                        </div>
                    </div>
                    <div className="arcanum-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Maintenance
                                </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.props.data.maintenance}
                            </div>

                        </div>
                        <div>
                            <div className="arcanum-spell-expandable-item-section1-column-header">
                                Type
                                </div>
                            <div className="arcanum-spell-expandable-item-section1-column-value">
                                {this.getType()}
                            </div>
                        </div>
                    </div>
                </div>
                <div className="arcanum-spell-expandable-item-breakline" />
                <div className="arcanum-spell-expandable-item-section2">
                    <div className="arcanum-spell-expandable-item-section2-effect">
                        <strong>Effect:</strong> <Text value={this.props.data.effect} onHighlight={this.onHighlight} />
                    </div>
                    {this.props.data.reachEffects.length > 0 && 
                        <div className="arcanum-spell-expandable-item-section2-reach">
                            <strong>Reaches:</strong> 
                            {this.getReachEffect()}
                        </div>
                    }
                    {this.props.data.schoolEffects.length > 0 &&
                        <div className="arcanum-spell-expandable-item-section2-school">
                            {/* <strong>School:</strong>  */}
                            {this.getSchoolEffect()}
                        </div>
                    }
                </div>
                <div className="arcanum-spell-expandable-item-section3">
                    <div>Tags:</div> {this.getTags()}
                </div>
            </div>
        );
    }

    getArcanumSpellClasses() {
        var classes = ["arcanum-spell"];

        if (this.state.isHighlight && !this.state.hasHighlight) {
            classes.push("arcanum-spell-hidden");
        }

        return classes.join(" ")
    }

    render() {
        return (

            <div className={this.getArcanumSpellClasses()}>
                <div className="arcanum-spell-header"
                    onMouseDown={this.toggleShow}
                >
                    <div className={"arcanum-spell-header-icon arcanum-spell-icon-" + this.props.school.toLowerCase()} />

                    <div className="arcanum-spell-header-lv">
                        {this.props.data.level}
                    </div>

                    <div className="arcanum-spell-header-name-container">
                        <div className="arcanum-spell-header-name">{this.props.data.name}</div>
                        <div className="arcanum-spell-header-school">{this.props.school}</div>
                    </div>

                    <div className="arcanum-spell-header-cost">
                        -
                    </div>

                    <div className="arcanum-spell-header-maintenance">
                        {/* {this.props.data.maintenanceDuration} */}
                    </div>

                    <div className="arcanum-spell-header-type">
                        {/* {this.getType()} */}
                    </div>

                    <div className="arcanum-spell-header-action">
                        {/* {this.props.data.action} */}
                    </div>
                </div>

                {this.getExpanded()}
            </div>
        );
    }
}

export default ArcanumSpell;
