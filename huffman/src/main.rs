use std::collections::HashMap;

mod utils;
mod structures;

use utils::{
    frequency,
    new_box,
    assign_codes,
    encode_string,
    decode_string,
};
use structures::{ Node };

fn main() {
    let f = frequency("abaabcd");

    let mut p:Vec<Box<Node>> =
        f.iter()
        .map(|x| new_box(Node::new(*(x.1), Some(*(x.0)))))
        .collect();

    while p.len() > 1 {
        p.sort_by(|a, b| (&(b.frequency)).cmp(&(a.frequency)));
        let a = p.pop().unwrap();
        let b = p.pop().unwrap();
        let mut c = new_box(Node::new(a.frequency + b.frequency, None));
        c.left = Some(a);
        c.right = Some(b);
        p.push(c);
    }

    let root = p.pop().unwrap();

    let mut h:HashMap<char, String> = HashMap::new();
    assign_codes(&root, &mut h, "".to_string());
}
