import React from 'react';
import './style/card-category.css';
import Card from './card';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { 
    faChevronRight, 
    faChevronDown, 
} from '@fortawesome/free-solid-svg-icons';

class CardCategory extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            name: props.data.name,
            expanded: false
        };

        this.toggle = this.toggle.bind(this);
    }

    toggle = () => this.setState({expanded: !this.state.expanded});

    getCards() {
        var cards = [];

        for(var spell of this.props.data.spells) {
            cards.push(<Card key={spell.name} data={spell} />);
        }

        return cards;
    }

    getIcon() {
        return this.state.expanded
            ? faChevronDown
            : faChevronRight;
    }

    getContentClass() {
        var classes = ["card-category-content"];

        if(this.state.expanded) {
            classes.push("card-category-content-expanded");
        }
        else {
            classes.push("card-category-content-collapsed");
        }

        return classes.join(" ");
    }

    getContent() {
        if(this.props.data.spells.length == 0)
            return null;

        return (
            <div className={this.getContentClass()}>
                {this.getCards()}
            </div>
        );
    }

    render() {
        return (
            <div className="card-category-container">
                <div className="card-category-header" onMouseDown={this.toggle}>
                    <div>{this.state.name} ({this.props.data.spells.length})</div> <FontAwesomeIcon icon={this.getIcon()} /></div>
                {this.getContent()}
            </div>
        );
    } 
}

export default CardCategory;
