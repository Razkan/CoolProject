import React from 'react';
import { connect } from 'react-redux';
import './text.css';

const mapStateToProps = (state) => ({ highlight: state.highlight.value });

class Text extends React.Component {
	constructor(props) {
		super(props);

		this.onHighlight = this.props.onHighlight
			? this.props.onHighlight
			: () => { };
	}

	getHighlightText(text, highlight) {
		highlight = highlight.toLowerCase();
		
		const getIndex = (text) => {
			return text.toLowerCase().indexOf(highlight);
		}
		
		if(getIndex(text) === -1) {
			return [];
		}

		const findHighlightedWords = text => {
			var arrayOfWordArray = [];
			var textArr = text.split(" ");	

			for (var word of textArr) {

				var wordArr = [];
				for (var index = getIndex(word); index > -1; index = getIndex(word)) {
	
					var begin = word.substring(0, index);
					var match = word.substring(index, index + highlight.length);
	
					word = word.substring(index + highlight.length, word.length);
	
					wordArr.push({ begin, match, end: "" });
				}
	
				if (word) {
					wordArr.push({ begin: "", match: "", end: word });
				}

				arrayOfWordArray.push(wordArr);
			}
			
			return arrayOfWordArray;
		};

		const createHTML = array => {
			var textArr = [];
			for (var wordArr of array) {
				var text = "<div style=\"display: flex; flex-wrap: wrap; white-space: pre;\">";
				for (var word of wordArr) {
	
					if (word.begin) {
						text += word.begin;
					}
					if (word.match) {
						text += "<div style=\"background-color: yellow;\">" + word.match + "</div>";
	
					}
					if (word.end) {
						text += word.end;
					}
				}
				text += "<div>&nbsp;</div></div>";
				textArr.push(text);
			}

			return textArr;
		};
		
		var arrayOfWordArray = findHighlightedWords(text);
		var textArr = createHTML(arrayOfWordArray);
		return textArr.join("");
	}

	render() {
		var value = this.props.value;
		var highlight = this.props.highlight;

		if (highlight) {

			var html = this.getHighlightText(value, highlight);
			if (html.length > 0) {

				this.onHighlight(true, true);

				const textContainer = {
					display: "flex",
					flexWrap: "wrap",
					whiteSpace: "pre"
				}

				var innerHtml = { __html: html };
				return (
					<div style={textContainer} dangerouslySetInnerHTML={innerHtml}>
					</div>
				);
			}
		}

		this.onHighlight(!!highlight, false);
		return (
			<div>{value}</div>
		);
	}
}

export default connect(mapStateToProps)(Text);
