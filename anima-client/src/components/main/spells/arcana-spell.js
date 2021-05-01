import React from 'react';
import './style/arcana-spell.css';
import Text from '../../../redux/highlight/text';

class ArcanaSpell extends React.Component {

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

        return tags.map(tag => <div key={tag} className="arcana-spell-tag">{tag}</div>);
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

    getAddedEffect() {
        
        var levels = <tr><td>Level</td>{this.props.data.spellLevel.map((level, i) => <th key={i}>{level.name}</th>)}</tr>;
        var zeon = <tr><td>Zeon</td>{this.props.data.spellLevel.map((level, i) => <td key={i}>{level.zeon}</td>)}</tr>;
        var req = <tr><td>Req</td>{this.props.data.spellLevel.map((level, i) => <td key={i}>{level.intellectRequirement}</td>)}</tr>;
        var text = <div>{this.props.data.spellLevel.map((level, i) => <div key={i}><strong>{level.name}: </strong>{level.effect}</div>)}</div>;
        
        const style = {
            display: "flex",
            flexDirection: "column"
        };

        return (
            <div className="arcana-spell-container">
                <div className="arcana-spell-added-effect">
                    <table>
                        <tbody>
                            {levels}
                            {zeon}
                            {req}
                        </tbody>
                    </table>
                </div>
                {text}
            </div>
        );
    }

    getExpandedClasses() {
        var classes = ["arcana-spell-expandable-item"];

        if (!this.state.show && !this.state.hasHighlight) {
            classes.push("arcana-spell-expandable-item-hidden");
        }

        return classes.join(" ");
    }

    getExpanded() {
        return (
            <div className={this.getExpandedClasses()}>
                <div className="arcana-spell-expandable-item-section1">
                    <div className="arcana-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Level
                                </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.props.data.level}
                            </div>
                        </div>
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                School
                            </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.props.school}
                            </div>
                        </div>
                    </div>
                    <div className="arcana-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Cost
                                </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                -
                            </div>
                        </div>
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Resistance(s)
                            </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.getResistance()}
                            </div>

                        </div>
                    </div>
                    <div className="arcana-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Maximum Zeon
                            </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.props.data.zeonAttribute} {this.props.data.maximumZeon}
                            </div>
                        </div>
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Action
                                </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.props.data.action}
                            </div>
                        </div>
                    </div>
                    <div className="arcana-spell-expandable-item-section1-column">
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Maintenance
                                </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.props.data.maintenance}
                            </div>

                        </div>
                        <div>
                            <div className="arcana-spell-expandable-item-section1-column-header">
                                Type
                                </div>
                            <div className="arcana-spell-expandable-item-section1-column-value">
                                {this.getType()}
                            </div>
                        </div>
                    </div>
                </div>
                <div className="arcana-spell-expandable-item-breakline" />
                <div className="arcana-spell-expandable-item-section2">
                    <div className="arcana-spell-expandable-item-section2-effect">
                        <strong>Effect:</strong> <Text value={this.props.data.effect} onHighlight={this.onHighlight} />
                    </div>
                    <div className="arcana-spell-expandable-item-section2-added-effect">
                        {/* <strong>Added Effect:</strong>  */}
                        {this.getAddedEffect()}
                    </div>
                </div>
                <div className="arcana-spell-expandable-item-section3">
                    <div>Tags:</div> {this.getTags()}
                </div>
            </div>
        );
    }

    getArcanaSpellClasses() {
        var classes = ["arcana-spell"];

        if (this.state.isHighlight && !this.state.hasHighlight) {
            classes.push("arcana-spell-hidden");
        }

        return classes.join(" ")
    }

    render() {
        return (

            <div className={this.getArcanaSpellClasses()}>
                <div className="arcana-spell-header"
                    onMouseDown={this.toggleShow}
                >
                    <div className={"arcana-spell-header-icon arcana-spell-icon-" + this.props.school.toLowerCase()} />

                    <div className="arcana-spell-header-lv">
                        {this.props.data.level}
                    </div>

                    <div className="arcana-spell-header-name-container">
                        <div className="arcana-spell-header-name">{this.props.data.name}</div>
                        <div className="arcana-spell-header-school">{this.props.school}</div>
                    </div>

                    <div className="arcana-spell-header-cost">
                        -
                    </div>

                    <div className="arcana-spell-header-maintenance">
                        {this.props.data.maintenanceDuration}
                    </div>

                    <div className="arcana-spell-header-type">
                        {this.getType()}
                    </div>

                    <div className="arcana-spell-header-action">
                        {this.props.data.action}
                    </div>
                </div>

                {this.getExpanded()}
            </div>
        );
    }
}

export default ArcanaSpell;
